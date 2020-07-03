using Application.Dto;
using MediatR;

namespace Application.Mediator.Courses.Queries.GetCourse
{
    public class GetCourseQuery : IRequest<CourseResponse>
    {
        public long CourseId { get; set; }
    }
}