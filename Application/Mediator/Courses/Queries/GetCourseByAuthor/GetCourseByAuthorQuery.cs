using Application.Dto;
using MediatR;

namespace Application.Mediator.Courses.Queries.GetCourseByAuthor
{
    public class GetCourseByAuthorQuery : IRequest<CourseResponse>
    {
        public long CourseId { get; set; }
    }
}