using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Infrastructure.Persistence;
using Domain.Entity.Intermediate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Lessons.Commands.LikeLesson
{
    public class LikeLessonCommandHandler : IRequestHandler<LikeLessonCommand, int>
    {
        private readonly ApiDataContext _context;
        private readonly ICurrentUserService _currentUser;

        public LikeLessonCommandHandler(ApiDataContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<int> Handle(LikeLessonCommand request, CancellationToken cancellationToken)
        {
            var likedLesson = await _context.LessonsLikes.FindAsync(request.LessonId, _currentUser.UserId);

            if (likedLesson == null)
            {
                likedLesson = new UserLessonLikesEntity
                {
                    LessonId = request.LessonId,
                    UserId = _currentUser.UserId
                };

                await _context.LessonsLikes.AddAsync(likedLesson, cancellationToken);
            }
            else _context.LessonsLikes.Remove(likedLesson);

            await _context.SaveChangesAsync(cancellationToken);

            return _context.LessonsLikes.AsNoTracking().Count(x => x.LessonId == request.LessonId);
        }
    }
}