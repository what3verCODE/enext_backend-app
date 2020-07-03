using System.Collections.Generic;
using Application.Dto;
using MediatR;

namespace Application.Mediator.Courses.Queries.GetCourses
{
    public class GetCoursesQuery : IRequest<List<CourseResponse>>
    {
        public int Count { get; set; }
        public bool IsAdmin { get; set; }
    }
}