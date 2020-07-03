using System.Collections.Generic;
using Application.Dto;
using MediatR;

namespace Application.Mediator.Comments.Queries.GetComments
{
    public class GetCommentsQuery : IRequest<List<CommentResponse>>
    {
        public long LessonId { get; set; }
    }
}