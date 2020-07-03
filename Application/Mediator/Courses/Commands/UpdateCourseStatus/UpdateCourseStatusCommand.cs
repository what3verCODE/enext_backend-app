using Domain.Enum;
using MediatR;

namespace Application.Mediator.Courses.Commands.UpdateCourseStatus
{
    public class UpdateCourseStatusCommand : IRequest
    {
        public long CourseId { get; set; }
        public CourseStatus Status { get; set; }
    }
}