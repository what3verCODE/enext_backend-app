using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Identity.Commands.LogoutUser
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand>
    {
        private readonly ApiDataContext _context;
        private readonly ICurrentUserService _currentUser;

        public LogoutUserCommandHandler(ApiDataContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            var token = await _context.RefreshTokens
                .AsNoTracking()
                .Where(x => x.UserId == _currentUser.UserId && x.Token == request.RefreshToken)
                .FirstOrDefaultAsync(cancellationToken);

            _context.RefreshTokens.Remove(token);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}