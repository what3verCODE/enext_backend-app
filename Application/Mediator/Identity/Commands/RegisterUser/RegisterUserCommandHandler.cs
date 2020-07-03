using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Mediator.Identity.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly UserManager<UserEntity> _manager;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(UserManager<UserEntity> manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var isExistingUser = await _manager.FindByEmailAsync(request.Email);
            
            if(isExistingUser != null)
                throw new AuthenticationException("User already exist");

            var user = _mapper.Map<RegisterUserCommand, UserEntity>(request);
            user.UserName = request.Email;

            var created = await _manager.CreateAsync(user, request.Password);

            if (!created.Succeeded)
                throw new AuthenticationException("User have not been created");
            
            return Unit.Value;
        }
    }
}