using MediatR;

namespace Application.Mediatr.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommand : IRequest
    {
        public long CourseId { get; set; }
    }
}