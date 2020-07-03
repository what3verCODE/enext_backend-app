using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Infrastructure.Persistence;
using Domain.Entity;
using MediatR;

namespace Application.Mediator.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, long>
    {
        private readonly ApiDataContext _context;
        private readonly ICurrentUserService _currentUser;

        public CreateCommentCommandHandler(ApiDataContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<long> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new CommentEntity
            {
                AuthorId = _currentUser.UserId,
                LessonId = request.LessonId,
                Text = request.Text,
                WrittenAt = DateTime.Now
            };

            await _context.Comments.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return comment.Id;
        }
    }
}