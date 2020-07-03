using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Lessons.Commands.UpdateLesson
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, LessonResponse>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;

        public UpdateLessonCommandHandler(ApiDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LessonResponse> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons
                .Where(x => x.Id == request.Id)
                .Include(x => x.Module).ThenInclude(y => y.Course)
                .Include(x => x.Sections)
                .ThenInclude(z => z.Quiz)
                .ThenInclude(y => y.Questions)
                .ThenInclude(c => c.Answers)
                .FirstOrDefaultAsync(cancellationToken);
            
            if(lesson == null)
                throw new NotFoundException(nameof(LessonEntity), request.Id);
            
            if(lesson.Module.Course.Status == CourseStatus.Published || lesson.Module.Course.Status == CourseStatus.AwaitingPublication)
                throw new CourseStatusException(nameof(CourseEntity), request.Id);

            var updated = _mapper.Map<UpdateLessonCommand, LessonEntity>(request);
            
            foreach (var section in lesson.Sections)
            {
                if (section.Type == LessonSectionType.Quiz)
                {
                    foreach (var question in section.Quiz.Questions)
                    {
                        foreach (var answer in question.Answers)
                        {
                            if (!request.Sections.Any(x =>
                                x.Quiz != null && x.Quiz.Questions.Any(y =>
                                    y.Answers.Any(c =>
                                        c.Id == answer.Id))))
                                _context.Answers.Remove(answer);
                        }

                        if (!request.Sections.Any(x => 
                            x.Quiz != null && x.Quiz.Questions.Any(y => 
                                y.Id == question.Id)))
                            _context.Questions.Remove(question);
                    }
                }
                
                if (request.Sections.All(x => x.Id != section.Id))
                    _context.Sections.Remove(section);
            }

            lesson.Title = updated.Title;
            lesson.Sections = updated.Sections;
            lesson.MaxScore = lesson.Sections
                .Where(section => section.Type == LessonSectionType.Quiz)
                .Sum(section => section.Quiz.Questions.Sum(question => question.Score));

            _context.Lessons.Update(lesson);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LessonEntity, LessonResponse>(lesson);
        }
    }
}