using System.Threading.Tasks;
using Application.Dto;
using Application.Mediator.Lessons.Queries.GetLastVisitedLesson;
using Application.Mediator.Lessons.Commands.LikeLesson;
using Application.Mediator.Lessons.Commands.UpdateLesson;
using Application.Mediator.Lessons.Queries.GetLesson;
using Application.Mediator.Lessons.Queries.GetLessonWithoutAnswers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    public class LessonsController : ApiController
    {
        /// <summary>
        /// Returns last visited lesson
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{courseId}/continue")]
        public async Task<ActionResult<long>> GetLastVisited(long courseId)
            => await Mediator.Send(new GetLastVisitedLessonQuery {CourseId = courseId});
        
        /// <summary>
        /// Returns lesson with all info (excluding correct answer flag)
        /// </summary>
        /// <param name="lessonId">Lesson ID</param>
        /// <returns>Lesson</returns>
        [Authorize]
        [HttpGet("{lessonId}/without-answers")]
        public async Task<ActionResult<LessonWithoutAnswersResponse>> GetWithoutAnswers(long lessonId)
            => await Mediator.Send(new GetLessonWithoutAnswersQuery {LessonId = lessonId});

        /// <summary>
        /// Returns lesson with all info (sections/quizzes/questions/answers with correct flag)
        /// </summary>
        /// <param name="lessonId">Lesson ID</param>
        /// <returns>Lesson</returns>
        [Authorize]
        [HttpGet("{lessonId}")]
        public async Task<ActionResult<LessonResponse>> Get(long lessonId)
            => await Mediator.Send(new GetLessonQuery {LessonId = lessonId});

        /// <summary>
        /// Updates lesson with sections/quizzes/etc 
        /// </summary>
        /// <param name="id">Lesson ID</param>
        /// <returns>Updated lesson</returns>
        [Authorize]
        [HttpPut("{lessonId}")]
        public async Task<ActionResult<LessonResponse>> Update(long lessonId, UpdateLessonCommand command)
        {
            if (lessonId != command.Id)
                return BadRequest();
            return await Mediator.Send(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lessonId"></param>
        /// <returns>Lesson likes count</returns>
        [Authorize]
        [HttpPost("{lessonId}/like")]
        public async Task<ActionResult<int>> Like(long lessonId)
            => await Mediator.Send(new LikeLessonCommand {LessonId = lessonId});
    }
}