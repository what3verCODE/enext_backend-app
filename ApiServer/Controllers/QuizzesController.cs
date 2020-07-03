using System.Threading.Tasks;
using Application.Dto;
using Application.Mediator.Quizzes.Command.ValidateQuiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    public class QuizzesController : ApiController
    {
        /// <summary>
        /// Returns validated quiz with incorrect choices
        /// </summary>
        /// <param name="quizId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("{quizId}/validate")]
        public async Task<ActionResult<QuizValidationResponse>> Validate(long quizId, ValidateQuizCommand command)
        {
            if (quizId != command.Id)
                return BadRequest();
            
            return await Mediator.Send(command);
        }
    }
}