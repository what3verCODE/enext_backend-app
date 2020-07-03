using MediatR;

namespace Application.Mediator.Identity.Commands.LogoutUser
{
    public class LogoutUserCommand : IRequest
    {
        public string RefreshToken { get; set; }
    }
}