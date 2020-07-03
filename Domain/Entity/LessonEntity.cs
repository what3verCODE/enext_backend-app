using System.Collections.Generic;
using Domain.Abstract;
using Domain.Entity.Intermediate;

namespace Domain.Entity
{
    public class LessonEntity : AuditableEntity
    {
        public long Id { get; set; }
        public long ModuleId { get; set; }
        public string Title { get; set; }
        public bool ManualChecking { get; set; }
        public int MaxScore { get; set; }

        public virtual ICollection<LessonSectionEntity> Sections { get; set; }
        public virtual ICollection<CommentEntity> Comments { get; set; }
        public virtual ICollection<UserLessonLikesEntity> UsersLikes { get; set; }
        public virtual ICollection<ProgressEntity> Progresses { get; set; }
        public ModuleEntity Module { get; set; }
    }
}