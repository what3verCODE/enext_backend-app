using Application.Dto;
using MediatR;

namespace Application.Mediator.Progresses.Queries.GetProgress
{
    public class GetProgressQuery : IRequest<ProgressResponse>
    {
        public long ProgressId { get; set; }
    }
}