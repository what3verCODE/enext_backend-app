using System.Threading.Tasks;
using Domain.Entity;

namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<UserEntity> GetUserAsync(string userId);
    }
}