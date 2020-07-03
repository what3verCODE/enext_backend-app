using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Comments.Queries.GetComments
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<CommentResponse>>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;

        public GetCommentsQueryHandler(ApiDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CommentResponse>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _context.Comments
                .AsNoTracking()
                .Where(x => x.LessonId == request.LessonId)
                .Include(x => x.Author)
                .Include(x => x.UsersLikes)
                .Include(x => x.Replies).ThenInclude(x => x.Author)
                .Include(x => x.Replies).ThenInclude(x => x.UsersLikes)
                .ProjectTo<CommentResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return comments;
        }
    }
}