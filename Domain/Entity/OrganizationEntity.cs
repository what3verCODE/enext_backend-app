using System.Collections.Generic;
using Domain.Enum;

namespace Domain.Entity
{
    public class OrganizationEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrganizationType Type { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
    }
}