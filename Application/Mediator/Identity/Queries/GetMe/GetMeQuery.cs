using Application.Dto;
using MediatR;

namespace Application.Mediator.Identity.Queries.GetMe
{
    public class GetMeQuery : IRequest<UserResponse>
    { }
}