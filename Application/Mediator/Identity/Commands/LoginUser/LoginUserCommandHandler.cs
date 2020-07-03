using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Dto;
using Application.Mediator.Identity.Commands.GenerateToken;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Mediator.Identity.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
    {
        private readonly UserManager<UserEntity> _manager;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(UserManager<UserEntity> manager, IMediator mediator, IMapper mapper)
        {
            _manager = manager;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _manager.FindByEmailAsync(request.Email);
            
            if(user == null)
                throw new AuthenticationException("User does not exist");

            var isPasswordValid = await _manager.CheckPasswordAsync(user, request.Password);
            
            if(!isPasswordValid)
                throw new AuthenticationException("Password is incorrect");

            var token = await _mediator.Send(new GenerateTokenCommand {User = user}, cancellationToken);

            return new LoginResponse
            {
                User = _mapper.Map<UserEntity, UserResponse>(user),
                Token = token
            };
        }
    }
}