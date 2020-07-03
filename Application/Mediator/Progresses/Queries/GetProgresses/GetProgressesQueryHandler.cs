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

namespace Application.Mediator.Progresses.Queries.GetProgresses
{
    public class GetProgressesQueryHandler : IRequestHandler<GetProgressesQuery, List<ProgressComplexResponse>>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;

        public GetProgressesQueryHandler(ApiDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProgressComplexResponse>> Handle(GetProgressesQuery request, CancellationToken cancellationToken)
        {
            var progresses = await _context.Progresses
                .AsNoTracking()
                .Where(x => x.CourseId == request.CourseId)
                .Include(x => x.Attempts)
                .Include(x => x.User)
                .Include(x => x.Lesson)
                .ToListAsync(cancellationToken);

            // Calc percent foreach lesson + if lesson have max score get percent for individual score (1 = ...%)
            var total = progresses.Select(x => x.Lesson).Distinct();
            var lessonEntities = total as LessonEntity[] ?? total.ToArray();
            var totalLessonsToVisit = lessonEntities.Count();
            double percentPerVisitedLesson = 100 / totalLessonsToVisit;
            var lessonsPercent = new List<LessonPercent>();

            foreach (var lesson in lessonEntities)
            {
                var lessonPercent = new LessonPercent {Id = lesson.Id};
                if (lesson.MaxScore != 0)
                    lessonPercent.Percent = percentPerVisitedLesson / lesson.MaxScore;
                else lessonPercent.Percent = percentPerVisitedLesson;
                
                lessonsPercent.Add(lessonPercent);
            }

            var result = new List<ProgressComplexResponse>();
            foreach (var progress in progresses)
            {
                var progressForUser = result.FirstOrDefault(x => x.User.Id == progress.UserId);
                var percent = lessonsPercent.FirstOrDefault(x => x.Id == progress.LessonId).Percent;
                
                if (progressForUser == null)
                {
                    var _progressForUser = new ProgressComplexResponse
                    {
                        Id = progress.Id,
                        Index = result.Count + 1,
                        User = _mapper.Map<UserEntity, UserResponse>(progress.User),
                        ClassName = ""
                    };

                    if (progress.Lesson.MaxScore != 0)
                    {
                        _progressForUser.Progress = (int)(percent * progress.Score);
                    }
                    else
                    {
                        _progressForUser.Progress = progress.IsVisited ? (int) percent : 0;
                    }
                    
                    result.Add(_progressForUser);
                }
                else
                {
                    if (progress.Lesson.MaxScore != 0)
                    {
                        progressForUser.Progress += (int) percent * progress.Score;
                    }
                    else
                    {
                        progressForUser.Progress += progress.IsVisited ? (int) percent : 0;
                    }
                }
            }

            
            return result;
        }

        private class LessonPercent
        {
            public long Id { get; set; }
            public double Percent { get; set; }
        }
    }
}