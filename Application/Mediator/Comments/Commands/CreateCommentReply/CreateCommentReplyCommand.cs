using MediatR;

namespace Application.Mediator.Comments.Commands.CreateCommentReply
{
    public class CreateCommentReplyCommand : IRequest<long>
    {
        public long LessonId { get; set; }
        public string Text { get; set; }
        public long RootCommentId { get; set; }
    }
}