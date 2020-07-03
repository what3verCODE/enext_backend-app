using System.Collections.Generic;
using Domain.Abstract;

namespace Domain.Entity
{
    public class ModuleEntity : AuditableEntity
    {
        public long Id { get; set; }
        public long CourseId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<LessonEntity> Lessons { get; set; }

        public CourseEntity Course { get; set; }
    }
}