using System.Linq;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ApiServer.Services.CurrentUser
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var context = httpContextAccessor.HttpContext?.User?.Claims.ToList();
            
            if (context != null && context.Any()){
                UserId = context.Single(x => x.Type == "Id")?.Value;
            }
        }
        public string UserId { get; }
    }
}