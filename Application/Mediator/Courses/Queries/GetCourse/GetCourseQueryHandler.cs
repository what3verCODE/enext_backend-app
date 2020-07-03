using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Courses.Queries.GetCourse
{
    public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseResponse>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;

        public GetCourseQueryHandler(ApiDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CourseResponse> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .Where(x => x.Id == request.CourseId)
                .Include(x => x.Modules).ThenInclude(y => y.Lessons)
                .Include(x => x.Authors).ThenInclude(y => y.Author)
                .Include(x => x.UsersLikes)
                .FirstOrDefaultAsync(cancellationToken);
            
            if(course == null)
                throw new NotFoundException(nameof(CourseEntity), request.CourseId);

            return _mapper.Map<CourseEntity, CourseResponse>(course);
        }
    }
}