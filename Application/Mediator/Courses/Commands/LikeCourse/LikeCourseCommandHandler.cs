using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Infrastructure.Persistence;
using Domain.Entity.Intermediate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Courses.Commands.LikeCourse
{
    public class LikeCourseCommandHandler : IRequestHandler<LikeCourseCommand, int>
    {
        private readonly ApiDataContext _context;
        private readonly ICurrentUserService _currentUser;

        public LikeCourseCommandHandler(ApiDataContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<int> Handle(LikeCourseCommand request, CancellationToken cancellationToken)
        {
            var likedCourse = await _context.CoursesLikes.FindAsync(request.CourseId, _currentUser.UserId);

            if (likedCourse == null)
            {
                likedCourse = new UserCourseLikesEntity
                {
                    CourseId = request.CourseId,
                    UserId = _currentUser.UserId
                };

                await _context.CoursesLikes.AddAsync(likedCourse, cancellationToken);
            }
            else _context.CoursesLikes.Remove(likedCourse);

            await _context.SaveChangesAsync(cancellationToken);

            return _context.CoursesLikes.AsNoTracking().Count(x => x.CourseId == request.CourseId);
        }
    }
}