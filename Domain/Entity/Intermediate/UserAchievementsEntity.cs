using System;

namespace Domain.Entity.Intermediate
{
    public class UserAchievementsEntity
    {
        public string UserId { get; set; }
        public long AchievementId { get; set; }
        public DateTime ReceivedAt { get; set; }

        public UserEntity User { get; set; }
        public AchievementEntity Achievement { get; set; }
    }
}