using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using Application.Mediator.Courses.Commands.CreateCourse;
using Application.Mediator.Courses.Commands.LikeCourse;
using Application.Mediator.Courses.Commands.UpdateCourseInfo;
using Application.Mediator.Courses.Commands.UpdateCourseSchedule;
using Application.Mediator.Courses.Queries.GetCourse;
using Application.Mediator.Courses.Queries.GetCourseByAuthor;
using Application.Mediator.Courses.Queries.GetCourses;
using Application.Mediator.Courses.Queries.GetCoursesByAuthor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    public class CoursesController : ApiController
    {
        /// <summary>
        /// Returns single course from system by id with its base information, including modules and lessons
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>Course</returns>
        [HttpGet("{courseId}")]
        public async Task<ActionResult<CourseResponse>> Get(long courseId)
            => await Mediator.Send(new GetCourseQuery {CourseId = courseId});

        /// <summary>
        /// Returns single course from system by id with its base information, including modules and lessons
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>Course</returns>
        [Authorize]
        [HttpGet("{courseId}/authored")]
        public async Task<ActionResult<CourseResponse>> GetByAuthor(long courseId)
            => await Mediator.Send(new GetCourseByAuthorQuery {CourseId = courseId});

        /// <summary>
        /// Returns all courses from system with its base information
        /// </summary>
        /// <returns>Courses</returns>
        [HttpGet]
        public async Task<ActionResult<List<CourseResponse>>> GetAll()
            => await Mediator.Send(new GetCoursesQuery());

        /// <summary>
        /// Returns all courses, where author is current user, from system with its base information
        /// </summary>
        /// <returns>Courses</returns>
        [Authorize]
        [HttpGet("authored")]
        public async Task<ActionResult<List<CourseResponse>>> GetAllByAuthor()
            => await Mediator.Send(new GetCoursesByAuthorQuery());
        
        
        /// <summary>
        /// Creates course
        /// </summary>
        /// <param name="command">Includes course title</param>
        /// <returns>Course Id</returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateCourseCommand command)
            => await Mediator.Send(command);
        
        /// <summary>
        /// Updates course base info
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="command"></param>
        /// <returns>Updated course</returns>
        [Authorize]
        [HttpPut("updateInfo/{courseId}")]
        public async Task<ActionResult<CourseResponse>> UpdateInfo(long courseId, UpdateCourseInfoCommand command)
        {
            if (courseId != command.Id)
                return BadRequest();

            return await Mediator.Send(command);
        }
        
        /// <summary>
        /// Updates course schedule
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="command"></param>
        /// <returns>Updated course</returns>
        [Authorize]
        [HttpPut("updateSchedule/{courseId}")]
        public async Task<ActionResult<CourseResponse>> UpdateSchedule(long courseId, UpdateCourseScheduleCommand command)
        {
            if (courseId != command.Id)
                return BadRequest();

            return await Mediator.Send(command);
        }

        /// <summary>
        /// Delete course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{courseId}")]
        public async Task<ActionResult> Delete(long courseId)
        {
            return Ok();
        }

        /// <summary>
        /// Likes course from current user if course not liked, and dislikes if course is liked
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>Number of current likes</returns>
        [Authorize]
        [HttpPost("{courseId}/like")]
        public async Task<ActionResult<int>> Like(long courseId)
            => await Mediator.Send(new LikeCourseCommand {CourseId = courseId});
    }
}