using MediatR;

namespace Application.Mediator.Courses.Commands.LikeCourse
{
    public class LikeCourseCommand : IRequest<int>
    {
        public long CourseId { get; set; }
    }
}