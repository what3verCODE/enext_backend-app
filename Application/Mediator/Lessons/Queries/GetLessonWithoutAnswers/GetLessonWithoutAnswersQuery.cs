using Application.Dto;
using MediatR;

namespace Application.Mediator.Lessons.Queries.GetLessonWithoutAnswers
{
    public class GetLessonWithoutAnswersQuery : IRequest<LessonWithoutAnswersResponse>
    {
        public long LessonId { get; set; }
    }
}