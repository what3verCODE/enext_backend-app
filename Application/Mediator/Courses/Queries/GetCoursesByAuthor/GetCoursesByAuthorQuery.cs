using System.Collections.Generic;
using Application.Dto;
using MediatR;

namespace Application.Mediator.Courses.Queries.GetCoursesByAuthor
{
    public class GetCoursesByAuthorQuery : IRequest<List<CourseResponse>>
    { }
}