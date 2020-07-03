using Application.Common.Models;

namespace Application.Dto
{
    public class LoginResponse
    {
        public UserResponse User { get; set; }
        public JsonWebTokenResult Token { get; set; }
    }
}