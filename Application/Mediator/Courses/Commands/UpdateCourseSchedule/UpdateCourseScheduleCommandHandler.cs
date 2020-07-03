using System;
using System.Collections.Generic;
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

namespace Application.Mediator.Courses.Commands.UpdateCourseSchedule
{
    public class UpdateCourseScheduleCommandHandler : IRequestHandler<UpdateCourseScheduleCommand, CourseResponse>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;

        public UpdateCourseScheduleCommandHandler(ApiDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CourseResponse> Handle(UpdateCourseScheduleCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses
                .Where(x => x.Id == request.Id)
                .Include(x => x.Modules).ThenInclude(y => y.Lessons)
                .Include(x => x.Authors).ThenInclude(y => y.Author)
                .FirstOrDefaultAsync(cancellationToken);
            
            if(course == null)
                throw new NotFoundException(nameof(CourseEntity), request.Id);
            
            if(course.Status == CourseStatus.Published || course.Status == CourseStatus.AwaitingPublication)
                throw new CourseStatusException(nameof(CourseEntity), request.Id);
            
            var modules = _mapper.Map<ICollection<UpdateCourseScheduleCommand.UpdateModule>, ICollection<ModuleEntity>>(request.Modules);
            
            foreach (var module in course.Modules)
            {
                if (modules.All(x => x.Id != module.Id))
                    _context.Modules.Remove(module);

                foreach (var lesson in module.Lessons)
                {
                    if (!modules.Any(x => x.Lessons.Any(y => y.Id == lesson.Id)))
                        _context.Lessons.Remove(lesson);
                }
            }

            course.Modules = modules;
            
            var progresses = await _context.Progresses
                .Where(x => x.CourseId == course.Id)
                .ToListAsync(cancellationToken);

            foreach (var progress in progresses.Where(progress => 
                !course.Modules.Any(x => 
                    x.Lessons.Any(y => 
                        y.Id == progress.LessonId)))) 
                _context.Progresses.Remove(progress);
            
            
            _context.Courses.Update(course);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CourseEntity, CourseResponse>(course);
        }
    }
}