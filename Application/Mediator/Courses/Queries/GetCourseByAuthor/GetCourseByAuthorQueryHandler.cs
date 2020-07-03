using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Courses.Queries.GetCourseByAuthor
{
    public class GetCourseByAuthorQueryHandler : IRequestHandler<GetCourseByAuthorQuery, CourseResponse>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;
        
        public GetCourseByAuthorQueryHandler(ApiDataContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<CourseResponse> Handle(GetCourseByAuthorQuery request, CancellationToken cancellationToken)
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
            
            if(course.Authors.All(x => x.AuthorId != _currentUser.UserId))
                throw new System.NotImplementedException();

            return _mapper.Map<CourseEntity, CourseResponse>(course);
        }
    }
}