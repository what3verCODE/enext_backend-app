using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entity;
using Domain.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Application.Mediator.Lessons.Queries.GetLessonWithoutAnswers
{
    public class GetLessonWithoutAnswersQueryHandler : IRequestHandler<GetLessonWithoutAnswersQuery, LessonWithoutAnswersResponse>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;

        public GetLessonWithoutAnswersQueryHandler(ApiDataContext context, IMapper mapper, ICurrentUserService currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<LessonWithoutAnswersResponse> Handle(GetLessonWithoutAnswersQuery request, CancellationToken cancellationToken)
        {
            var courseId = (await _context.Lessons
                .AsNoTracking()
                .Where(x => x.Id == request.LessonId)
                .Include(x => x.Module)
                .FirstOrDefaultAsync(cancellationToken)).Module.CourseId;

            var subscribed =
                await _context.Subscriptions.AnyAsync(
                    x => x.SubscriberId == _currentUser.UserId && x.CourseId == courseId, cancellationToken);
            
            if(!subscribed)
                throw new NotImplementedException();
                
            var lesson = await _context.Lessons
                .AsNoTracking()
                .Where(x => x.Id == request.LessonId)
                .Include(x => x.Sections).ThenInclude(z => z.Quiz).ThenInclude(y => y.Questions).ThenInclude(c => c.Answers)
                .Include(x => x.Sections).ThenInclude(z => z.Quiz).ThenInclude(y => y.Attempts)
                .Include(x => x.Comments).ThenInclude(z => z.Author)
                .Include(x => x.Comments).ThenInclude(z => z.UsersLikes)
                .Include(x => x.Comments).ThenInclude(z => z.Replies).ThenInclude(y => y.Author)
                .Include(x => x.Comments).ThenInclude(z => z.Replies).ThenInclude(y => y.UsersLikes)
                .FirstOrDefaultAsync(cancellationToken);

            if (lesson == null)
                throw new NotImplementedException();
            
            var progress = await _context.Progresses
                .AsNoTracking()
                .Where(x => x.LessonId == request.LessonId && x.UserId == _currentUser.UserId)
                .FirstOrDefaultAsync(cancellationToken);

            if (progress == null)
                throw new NotImplementedException();
            
            progress.IsVisited = true;
            _context.Progresses.Update(progress);

            var lastVisited = await _context.LastVisitedLessons
                .AsNoTracking()
                .Where(x => x.CourseId == courseId && x.UserId == _currentUser.UserId)
                .FirstOrDefaultAsync(cancellationToken);

            if (lastVisited == null)
            { 
                lastVisited = new LastVisitedLessonEntity
                {
                    CourseId = courseId,
                    UserId = _currentUser.UserId,
                    LessonId = lesson.Id
                };

                await _context.LastVisitedLessons.AddAsync(lastVisited, cancellationToken);
            }
            else
            {
                lastVisited.LessonId = lesson.Id;
                _context.LastVisitedLessons.Update(lastVisited);
            }

            var sections = lesson.Sections.Where(x => x.Type == LessonSectionType.Quiz).ToList();
            foreach (var section in sections)
                section.Quiz.MaxAttempts -= section.Quiz.Attempts.Count;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LessonEntity, LessonWithoutAnswersResponse>(lesson);
        }
    }
}