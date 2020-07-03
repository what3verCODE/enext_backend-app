using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediatr.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, Unit>
    {
        private readonly ApiDataContext _context;
        private readonly ICurrentUserService _currentUser;
        
        public DeleteSubscriptionCommandHandler(ApiDataContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _context.Subscriptions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.SubscriberId == _currentUser.UserId && x.CourseId == request.CourseId,
                    cancellationToken);
            
            if(subscription == null)
                throw new SubscriptionException("Subscription for this user does not exist");

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}