using System.Collections.Generic;
using Application.Dto;
using MediatR;

namespace Application.Mediator.Progresses.Commands.CreateProgress
{
    public class CreateProgressCommand : IRequest<List<ProgressResponse>>
    {
        public long CourseId { get; set; }
        public long LessonId { get; set; }
    }
}