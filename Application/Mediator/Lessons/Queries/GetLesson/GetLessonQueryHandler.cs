using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Lessons.Queries.GetLesson
{
    public class GetLessonQueryHandler : IRequestHandler<GetLessonQuery, LessonResponse>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;

        public GetLessonQueryHandler(ApiDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LessonResponse> Handle(GetLessonQuery request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons
                .AsNoTracking()
                .Where(x => x.Id == request.LessonId)
                .Include(x => x.Sections)
                .ThenInclude(z => z.Quiz)
                .ThenInclude(y => y.Questions)
                .ThenInclude(c => c.Answers)
                .Include(x => x.Comments)
                .ProjectTo<LessonResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (lesson == null)
                throw new System.NotImplementedException();

            return lesson;
        }
    }
}