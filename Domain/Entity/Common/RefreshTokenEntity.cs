using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Common
{
    public class RefreshTokenEntity
    {
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Used { get; set; }
        public bool Invalidated { get; set; }
        public string UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
    }
}