using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Courses.Queries.GetCoursesByAuthor
{
    public class GetCoursesByAuthorQueryHandler : IRequestHandler<GetCoursesByAuthorQuery, List<CourseResponse>>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;

        public GetCoursesByAuthorQueryHandler(ApiDataContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<List<CourseResponse>> Handle(GetCoursesByAuthorQuery request, CancellationToken cancellationToken)
        {
            var courses = await _context.Courses
                .AsNoTracking()
                .Include(x => x.Authors).ThenInclude(y => y.Author)
                .Where(x => x.Authors.Any(z => z.AuthorId == _currentUser.UserId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<CourseEntity>, List<CourseResponse>>(courses);
        }
    }
}