using Application.Dto;
using MediatR;

namespace Application.Mediator.Identity.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}