using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Infrastructure.Persistence;
using Domain.Entity;
using Domain.Entity.Intermediate;
using Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Mediator.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, long>
    {
        private readonly ApiDataContext _context;
        private readonly ICurrentUserService _currentUser;

        public CreateCourseCommandHandler(ApiDataContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }
        
        public async Task<long> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new CourseEntity
            {
                Title = request.Title,
                Status = CourseStatus.InDeveloping
            };
            
            course.Authors = new List<AuthorCourseEntity>
            {
                new AuthorCourseEntity
                {
                    CourseId = course.Id,
                    AuthorId = _currentUser.UserId
                }
            };

            await _context.Courses.AddAsync(course, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return course.Id;
        }
    }
}
