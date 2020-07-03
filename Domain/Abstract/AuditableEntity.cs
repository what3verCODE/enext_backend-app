using System;

namespace Domain.Abstract
{
    public abstract class AuditableEntity
    {
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}