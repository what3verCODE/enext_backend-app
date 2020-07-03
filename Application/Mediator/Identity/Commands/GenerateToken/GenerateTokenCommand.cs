using Application.Common.Models;
using Domain.Entity;
using MediatR;

namespace Application.Mediator.Identity.Commands.GenerateToken
{
    public class GenerateTokenCommand : IRequest<JsonWebTokenResult>
    {
        public UserEntity User { get; set; }
    }
}