using MediatR;

namespace Application.Mediator.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<long>
    {
        public long LessonId { get; set;}
        public string Text { get; set; }
    }
}