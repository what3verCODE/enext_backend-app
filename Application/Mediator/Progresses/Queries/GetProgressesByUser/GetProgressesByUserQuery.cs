using System.Collections.Generic;
using Application.Dto;
using MediatR;

namespace Application.Mediator.Progresses.Queries.GetProgressesByUser
{
    public class GetProgressesByUserQuery : IRequest<List<ProgressResponse>>
    {
        public long CourseId { get; set; }
        public string UserId { get; set; }
    }
}