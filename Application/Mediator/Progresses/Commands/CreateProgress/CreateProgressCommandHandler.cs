using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Dto;
using Application.Infrastructure.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediator.Progresses.Commands.CreateProgress
{
    public class CreateProgressCommandHandler : IRequestHandler<CreateProgressCommand, List<ProgressResponse>>
    {
        private readonly ApiDataContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;

        public CreateProgressCommandHandler(ApiDataContext context, ICurrentUserService currentUser, IMapper mapper)
        {
            _context = context;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<List<ProgressResponse>> Handle(CreateProgressCommand request, CancellationToken cancellationToken)
        {
            var progresses = await _context.Progresses
                .Where(x => x.CourseId == request.CourseId && x.UserId == _currentUser.UserId)
                .Include(x => x.Lesson)
                .ToListAsync(cancellationToken);

            if (progresses.All(x => x.LessonId != request.LessonId))
            {
                var progress = new ProgressEntity
                {
                    CourseId = request.CourseId,
                    LessonId = request.LessonId,
                    UserId = _currentUser.UserId,
                    IsVisited = true,
                    ManuallyChecked = !(progresses.FirstOrDefault(x => x.LessonId == request.LessonId).ManuallyChecked)
                };

                await _context.Progresses.AddAsync(progress, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                progresses.Add(progress);
            }
            
            

            return _mapper.Map<List<ProgressEntity>, List<ProgressResponse>>(progresses);
        }
    }
}