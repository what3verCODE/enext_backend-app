using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Infrastructure.Persistence;
using Domain.Common;
using Domain.Entity.Common;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Mediator.Identity.Commands.GenerateToken
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, JsonWebTokenResult>
    {
        private readonly ApiDataContext _context;
        private readonly JSONWebToken _jsonWebToken;

        public GenerateTokenCommandHandler(ApiDataContext context, JSONWebToken jsonWebToken)
        {
            _context = context;
            _jsonWebToken = jsonWebToken;
        }

        public async Task<JsonWebTokenResult> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jsonWebToken.Secret);

            var tokenExpiration = DateTime.UtcNow.AddSeconds(_jsonWebToken.TokenLifetime);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, request.User.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, request.User.Email),
                new Claim("Id", request.User.Id)
            };
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenExpiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            var refreshToken = new RefreshTokenEntity
            {
                Token = Guid.NewGuid().ToString(),
                JwtId = token.Id,
                UserId = request.User.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6)
            };
            
            await _context.RefreshTokens.AddAsync(refreshToken, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new JsonWebTokenResult()
            {
                Token = tokenHandler.WriteToken(token),
                TokenExpirationTime = ((DateTimeOffset)tokenExpiration).ToUnixTimeSeconds().ToString(),
                RefreshToken = refreshToken.Token
            };
        }
    }
}