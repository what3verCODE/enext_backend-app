using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Dto;
using Application.Mediator.Identity.Commands.LoginUser;
using Application.Mediator.Identity.Commands.LogoutUser;
using Application.Mediator.Identity.Commands.RefreshGeneratedToken;
using Application.Mediator.Identity.Commands.RegisterUser;
using Application.Mediator.Identity.Queries.GetMe;

namespace ApiServer.Controllers
{
    public class IdentityController : ApiController
    {
        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginUserCommand command) 
            => await Mediator.Send(command);
        
        /// <summary>
        /// DeAuthenticate user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("logout")]
        public async Task<ActionResult> Logout(LogoutUserCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        
        /// <summary>
        /// Returns refreshed token
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("refreshToken")]
        public async Task<ActionResult<RefreshTokenResponse>> RefreshToken(RefreshGeneratedTokenCommand command) 
            => await Mediator.Send(command);

        /// <summary>
        /// Returns user info
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UserResponse>> Me() 
            => await Mediator.Send(new GetMeQuery());
    }
}