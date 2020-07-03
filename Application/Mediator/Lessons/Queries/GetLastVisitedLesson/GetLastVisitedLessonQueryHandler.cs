using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Infrastructure.Persistence;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Lessons.Queries.GetLastVisitedLesson
{
    public class GetLastVisitedLessonQueryHandler : IRequestHandler<GetLastVisitedLessonQuery, long>
    {
        private readonly ApiDataContext _context;
        private readonly ICurrentUserService _currentUser;

        public GetLastVisitedLessonQueryHandler(ApiDataContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<long> Handle(GetLastVisitedLessonQuery request, CancellationToken cancellationToken)
        {
            var lastVisited = await _context.LastVisitedLessons
                .AsNoTracking()
                .Where(x => x.CourseId == request.CourseId && x.UserId == _currentUser.UserId)
                .FirstOrDefaultAsync(cancellationToken);

            if (lastVisited == null)
            {
                lastVisited = new LastVisitedLessonEntity
                {
                    CourseId = request.CourseId,
                    UserId = _currentUser.UserId,
                    LessonId = (await _context.Courses
                        .Where(x => x.Id == request.CourseId)
                        .Include(x => x.Modules)
                        .ThenInclude(y => y.Lessons)
                        .FirstOrDefaultAsync(cancellationToken)).Modules.First().Lessons.First().Id
                };

                await _context.LastVisitedLessons.AddAsync(lastVisited, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return lastVisited.LessonId;
        }
    }
}