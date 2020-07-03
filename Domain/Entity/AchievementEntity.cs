using System.Collections.Generic;
using Domain.Entity.Intermediate;

namespace Domain.Entity
{
    public class AchievementEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserAchievementsEntity> AchievementOwners { get; set; }
    }
}