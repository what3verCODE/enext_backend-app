using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Application.Dto;
using Application.Infrastructure.Persistence;
using Application.Mediator.Identity.Commands.GenerateToken;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Application.Mediator.Identity.Commands.RefreshGeneratedToken
{
    public class RefreshGeneratedTokenCommandHandler : IRequestHandler<RefreshGeneratedTokenCommand, RefreshTokenResponse>
    {
        private readonly UserManager<UserEntity> _manager;
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public RefreshGeneratedTokenCommandHandler(UserManager<UserEntity> manager, ApiDataContext context, IMediator mediator, TokenValidationParameters tokenValidationParameters, IMapper mapper)
        {
            _manager = manager;
            _context = context;
            _mediator = mediator;
            _tokenValidationParameters = tokenValidationParameters;
            _mapper = mapper;
        }

        public async Task<RefreshTokenResponse> Handle(RefreshGeneratedTokenCommand request, CancellationToken cancellationToken)
        {
            var validatedToken = GetPrincipalFromToken(request.Token);

            if (validatedToken == null)
                throw new RefreshTokenException("Invalid token");

            var expiryDateUnix = long.Parse(validatedToken.Claims.Single(x => 
                x.Type == JwtRegisteredClaimNames.Exp).Value);
            
            var expiryDateUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if (expiryDateUtc > DateTime.Now)
                throw new System.NotImplementedException();

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = _context.RefreshTokens
                .AsNoTracking()
                .SingleOrDefault(x => x.Token == request.RefreshToken);

            if (storedRefreshToken == null)
                throw new RefreshTokenException("This refresh token does not exist");
            if(storedRefreshToken.ExpiryDate < DateTime.UtcNow)
                throw new RefreshTokenException("This refresh token has expired");
            if (storedRefreshToken.Invalidated)
                throw new RefreshTokenException("This refresh token has been invalidated");
            if (storedRefreshToken.Used)
                throw new RefreshTokenException("This refresh token has been used");
            if (storedRefreshToken.JwtId != jti)
                throw new RefreshTokenException("This refresh token does not match this JWT");
            
            storedRefreshToken.Used = true;
            _context.RefreshTokens.Update(storedRefreshToken);
            await _context.SaveChangesAsync(cancellationToken);

            var user = await _manager.FindByIdAsync(validatedToken.Claims.Single(x =>
                x.Type == JwtRegisteredClaimNames.Jti).Value);

            var tokenResult = await _mediator.Send(new GenerateTokenCommand {User = user}, cancellationToken);
            
            return _mapper.Map<JsonWebTokenResult, RefreshTokenResponse>(tokenResult);
        }
        
        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                return !IsSecurityAlgorithmValid(validatedToken) ? null : principal;
            }
            catch
            {
                return null;
            }
        }
        private bool IsSecurityAlgorithmValid(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature,
                       StringComparison.InvariantCultureIgnoreCase);
        }
    }
}