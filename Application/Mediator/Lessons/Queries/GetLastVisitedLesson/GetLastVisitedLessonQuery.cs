using MediatR;

namespace Application.Mediator.Lessons.Queries.GetLastVisitedLesson
{
    public class GetLastVisitedLessonQuery : IRequest<long>
    {
        public long CourseId { get; set; }
    }
}