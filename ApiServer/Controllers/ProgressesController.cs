using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using Application.Mediator.Progresses.Commands.CreateProgress;
using Application.Mediator.Progresses.Queries.GetProgress;
using Application.Mediator.Progresses.Queries.GetProgresses;
using Application.Mediator.Progresses.Queries.GetProgressesByCurrentUser;
using Application.Mediator.Progresses.Queries.GetProgressesByUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    public class ProgressesController : ApiController
    {
        [Authorize]
        [HttpGet("single/{progressId}")]
        public async Task<ActionResult<ProgressResponse>> Get(long progressId) 
            => await Mediator.Send(new GetProgressQuery {ProgressId = progressId});

        [Authorize]
        [HttpGet("all/{courseId}")]
        public async Task<ActionResult<List<ProgressComplexResponse>>> GetAll(long courseId)
            => await Mediator.Send(new GetProgressesQuery {CourseId = courseId});

        [Authorize]
        [HttpGet("all/{courseId}/currentUser")]
        public async Task<ActionResult<List<ProgressResponse>>> GetByCurrentUser(long courseId)
            => await Mediator.Send(new GetProgressesByCurrentUserQuery {CourseId = courseId});

        [Authorize]
        [HttpGet("all/{courseId}/{userId}")]
        public async Task<ActionResult<List<ProgressResponse>>> GetByUser(long courseId, string userId)
            => await Mediator.Send(new GetProgressesByUserQuery {CourseId = courseId, UserId = userId});

        [Authorize]
        [HttpPost("{courseId}/{lessonId}")]
        public async Task<ActionResult<List<ProgressResponse>>> Create(long courseId, long lessonId)
            => await Mediator.Send(new CreateProgressCommand {CourseId = courseId, LessonId = lessonId});
    }
}