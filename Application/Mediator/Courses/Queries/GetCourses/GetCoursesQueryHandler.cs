using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Courses.Queries.GetCourses
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<CourseResponse>>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(ApiDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CourseResponse>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var queryableCourses = _context.Courses
                .AsNoTracking();
                
            if(!request.IsAdmin)    
                queryableCourses = queryableCourses.Where(x => x.Status == CourseStatus.Published);
             
            var courses = await queryableCourses
                .Include(x => x.UsersLikes)
                .ToListAsync(cancellationToken);

            if (request.Count > 0)
                courses = courses.Take(request.Count).ToList();
            
            return _mapper.Map<List<CourseEntity>, List<CourseResponse>>(courses);
        }
    }
}