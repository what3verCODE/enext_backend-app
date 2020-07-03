using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Infrastructure.Persistence;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Comments.Commands.CreateCommentReply
{
    public class CreateCommentReplyCommandHandler : IRequestHandler<CreateCommentReplyCommand, long>
    {
        private readonly ApiDataContext _context;
        private readonly ICurrentUserService _currentUser;

        public CreateCommentReplyCommandHandler(ApiDataContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<long> Handle(CreateCommentReplyCommand request, CancellationToken cancellationToken)
        {
            var rootComment = await _context.Comments.AnyAsync(x => x.Id == request.RootCommentId, cancellationToken);
            
            if(!rootComment)            
                throw new NotImplementedException();
            
            var reply = new CommentEntity
            {
                AuthorId = _currentUser.UserId,
                LessonId = request.LessonId,
                Text = request.Text,
                WrittenAt = DateTime.Now,
                RootCommentId = request.RootCommentId
            };

            await _context.Comments.AddAsync(reply, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return reply.Id;
        }
    }
}