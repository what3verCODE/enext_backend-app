using System.Threading.Tasks;
using Application.Mediatr.Subscriptions.Commands.CreateSubscription;
using Application.Mediatr.Subscriptions.Commands.DeleteSubscription;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    public class SubscriptionsController : ApiController
    {
        [Authorize]
        [HttpPost("{courseId}")]
        public async Task<ActionResult> Subscribe(long courseId, CreateSubscriptionCommand command)
        {
            if (courseId != command.CourseId)
                return BadRequest();
            await Mediator.Send(command);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{courseId}")]
        public async Task<ActionResult> Unsubscribe(long courseId, DeleteSubscriptionCommand command)
        {
            if (courseId != command.CourseId)
                return BadRequest();
            await Mediator.Send(command);
            return Ok();
        }
    }
}