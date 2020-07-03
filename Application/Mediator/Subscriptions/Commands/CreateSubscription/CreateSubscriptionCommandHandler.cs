using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Infrastructure.Persistence;
using Domain.Entity;
using Domain.Entity.Intermediate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediatr.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand>
    {
         private readonly ApiDataContext _context;
        private readonly ICurrentUserService _currentUser;

        public CreateSubscriptionCommandHandler(ApiDataContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _context.Subscriptions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.SubscriberId == _currentUser.UserId && x.CourseId == request.CourseId, cancellationToken);
            
            if(subscription != null)
                throw new SubscriptionException("Already subscribed");

            await _context.Subscriptions.AddAsync(new UserCourseEntity
            {
                SubscriberId = _currentUser.UserId,
                CourseId = request.CourseId
            }, cancellationToken);

            if (_context.Progresses
                .AsNoTracking()
                .Count(x => x.CourseId == request.CourseId && x.UserId == _currentUser.UserId) == 0)
            {
                var modules = await _context.Modules
                    .AsNoTracking()
                    .Where(x => x.CourseId == request.CourseId)
                    .Include(x => x.Lessons)
                    .ToListAsync(cancellationToken);

                foreach (var progress in from module in modules from lesson in module.Lessons select new ProgressEntity
                {
                    CourseId = request.CourseId,
                    LessonId = lesson.Id,
                    UserId = _currentUser.UserId,
                    IsVisited = false,
                    ManuallyChecked = !lesson.ManualChecking,
                    Score = 0
                })
                {
                    await _context.Progresses.AddAsync(progress, cancellationToken);
                }
            }
                
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}