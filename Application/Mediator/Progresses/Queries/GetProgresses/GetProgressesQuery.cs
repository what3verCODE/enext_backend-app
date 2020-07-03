using System.Collections.Generic;
using Application.Dto;
using MediatR;

namespace Application.Mediator.Progresses.Queries.GetProgresses
{
    public class GetProgressesQuery : IRequest<List<ProgressComplexResponse>>
    {
        public long CourseId { get; set; }
    }
}