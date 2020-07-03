using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Courses.Commands.UpdateCourseInfo
{
    public class UpdateCourseInfoCommandHandler : IRequestHandler<UpdateCourseInfoCommand, CourseResponse>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;

        public UpdateCourseInfoCommandHandler(ApiDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CourseResponse> Handle(UpdateCourseInfoCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses
                .Where(x => x.Id == request.Id)
                .Include(x => x.Modules).ThenInclude(y => y.Lessons)
                .Include(x => x.Authors).ThenInclude(y => y.Author)
                .FirstOrDefaultAsync(cancellationToken);
            
            if(course == null)
                throw new NotImplementedException();
            
            if(course.Status == CourseStatus.AwaitingPublication || course.Status == CourseStatus.Published)
                throw new NotImplementedException();

            course.Title = request.Title;
            course.Description = request.Description;
            course.ShortDescription = request.ShortDescription;
            course.TargetAudience = request.TargetAudience;
            course.Charge = request.Charge;
            course.Avatar = request.Avatar;

            _context.Courses.Update(course);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CourseEntity, CourseResponse>(course);
        }
    }
}