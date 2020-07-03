using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Progresses.Queries.GetProgressesByUser
{
    public class GetProgressesByUserQueryHandler : IRequestHandler<GetProgressesByUserQuery, List<ProgressResponse>>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;

        public GetProgressesByUserQueryHandler(ApiDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProgressResponse>> Handle(GetProgressesByUserQuery request, CancellationToken cancellationToken)
        {
            var progresses = await _context.Progresses
                .AsNoTracking()
                .Where(x => x.CourseId == request.CourseId && x.UserId == request.UserId)
                .Include(x => x.Attempts)
                .ToListAsync(cancellationToken);
            
            
            return _mapper.Map<List<ProgressEntity>, List<ProgressResponse>>(progresses);
        }
    }
}