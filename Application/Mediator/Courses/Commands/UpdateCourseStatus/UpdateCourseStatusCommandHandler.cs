using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Courses.Commands.UpdateCourseStatus
{
    public class UpdateCourseStatusCommandHandler : IRequestHandler<UpdateCourseStatusCommand>
    {
        private readonly ApiDataContext _context;
        

        public UpdateCourseStatusCommandHandler(ApiDataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCourseStatusCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses
                .FirstOrDefaultAsync(x => x.Id == request.CourseId, cancellationToken);
            
            if(course == null)
                throw new NotImplementedException();

            course.Status = request.Status;
            _context.Courses.Update(course);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}