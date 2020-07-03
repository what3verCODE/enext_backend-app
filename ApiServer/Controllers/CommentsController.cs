using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using Application.Mediator.Comments.Commands.CreateComment;
using Application.Mediator.Comments.Commands.CreateCommentReply;
using Application.Mediator.Comments.Queries.GetComments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    public class CommentsController : ApiController
    {
        [Authorize]
        [HttpGet("{lessonId}")]
        public async Task<ActionResult<List<CommentResponse>>> GetAll(long lessonId)
            => await Mediator.Send(new GetCommentsQuery {LessonId = lessonId});
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateCommentCommand command)
            => await Mediator.Send(command);

        [Authorize]
        [HttpPost("reply")]
        public async Task<ActionResult<long>> Reply([FromBody] CreateCommentReplyCommand command)
            => await Mediator.Send(command);
        
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Update()
        {
            return Ok();
        }
        
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            return Ok();
        }
    }
}
