using MediatR;

namespace Application.Mediatr.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommand : IRequest
    {
        public long CourseId { get; set; }
    }
}