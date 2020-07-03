namespace Application.Common.Models
{
    public class JsonWebTokenResult
    {
        public string Token { get; set; }
        public string TokenExpirationTime { get; set; }
        public string RefreshToken { get; set; }
    }
}