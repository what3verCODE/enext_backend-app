using System.Collections.Generic;
using Application.Dto;
using MediatR;

namespace Application.Mediator.Progresses.Queries.GetProgressesByCurrentUser
{
    public class GetProgressesByCurrentUserQuery : IRequest<List<ProgressResponse>>
    {
        public long CourseId { get; set; }
    }
}