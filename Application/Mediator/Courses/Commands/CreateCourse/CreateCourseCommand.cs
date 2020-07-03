using MediatR;

namespace Application.Mediator.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<long>
    {
        public string Title { get; set; }
    }
}