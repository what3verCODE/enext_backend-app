using Application.Dto;
using MediatR;

namespace Application.Mediator.Identity.Commands.RefreshGeneratedToken
{
    public class RefreshGeneratedTokenCommand : IRequest<RefreshTokenResponse>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}