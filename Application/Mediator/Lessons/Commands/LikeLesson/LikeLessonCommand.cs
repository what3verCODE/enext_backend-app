using MediatR;

namespace Application.Mediator.Lessons.Commands.LikeLesson
{
    public class LikeLessonCommand : IRequest<int>
    {
        public long LessonId { get; set; }
    }
}