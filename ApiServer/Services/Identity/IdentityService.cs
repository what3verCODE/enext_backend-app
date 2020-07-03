using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Infrastructure.Persistence;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiServer.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<UserEntity> _manager;
        private readonly ApiDataContext _context;

        public IdentityService(UserManager<UserEntity> manager, ApiDataContext context)
        {
            _manager = manager;
            _context = context;
        }

        public async Task<string> GetUserNameAsync(string userId) => (await GetUserAsync(userId)).UserName;
        public async Task<UserEntity> GetUserAsync(string userId) => await _manager.Users.FirstAsync(x => x.Id == userId);
    }
}