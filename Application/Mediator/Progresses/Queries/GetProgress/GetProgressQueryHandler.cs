using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Progresses.Queries.GetProgress
{
    public class GetProgressQueryHandler : IRequestHandler<GetProgressQuery, ProgressResponse>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;

        public GetProgressQueryHandler(ApiDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgressResponse> Handle(GetProgressQuery request, CancellationToken cancellationToken)
        {
            var progress = await _context.Progresses
                .AsNoTracking()
                .Where(x => x.Id == request.ProgressId)
                .Include(x => x.Attempts)
                .FirstOrDefaultAsync(cancellationToken);
            
            if(progress == null)
                throw new System.NotImplementedException();

            return _mapper.Map<ProgressEntity, ProgressResponse>(progress);
        }
    }
}