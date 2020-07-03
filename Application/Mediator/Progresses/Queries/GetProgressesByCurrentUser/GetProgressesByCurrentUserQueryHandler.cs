using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Progresses.Queries.GetProgressesByCurrentUser
{
    public class GetProgressesByCurrentUserQueryHandler : IRequestHandler<GetProgressesByCurrentUserQuery, List<ProgressResponse>>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;

        public GetProgressesByCurrentUserQueryHandler(ApiDataContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<List<ProgressResponse>> Handle(GetProgressesByCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var progresses = await _context.Progresses
                .AsNoTracking()
                .Where(x => x.CourseId == request.CourseId && x.UserId == _currentUser.UserId)
                .Include(x => x.Attempts)
                .ToListAsync(cancellationToken);
            
            
            return _mapper.Map<List<ProgressEntity>, List<ProgressResponse>>(progresses);
        }
    }
}