using Application.Dto;
using MediatR;

namespace Application.Mediator.Lessons.Queries.GetLesson
{
    public class GetLessonQuery : IRequest<LessonResponse>
    {
        public long LessonId { get; set; }
    }
}