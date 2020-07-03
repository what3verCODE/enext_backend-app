namespace Domain.Common
{
    public class JSONWebToken
    {
        public string Secret { get; set; }
        public int TokenLifetime { get; set; }
    }
}