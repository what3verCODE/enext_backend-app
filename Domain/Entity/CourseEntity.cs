using System.Collections.Generic;
using Domain.Abstract;
using Domain.Entity.Intermediate;
using Domain.Enum;

namespace Domain.Entity
{
    public class CourseEntity : AuditableEntity
    {
        public long Id { get; set; }
        public CourseStatus Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string TargetAudience { get; set; }
        public string Charge { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<AuthorCourseEntity> Authors { get; set; }
        public virtual ICollection<CourseClassEntity> Classes { get; set; }
        public virtual ICollection<ModuleEntity> Modules { get; set; }
        public virtual ICollection<UserCourseEntity> Subscribers { get; set; }
        public virtual ICollection<UserCourseLikesEntity> UsersLikes { get; set; }
        public virtual ICollection<ProgressEntity> Progresses { get; set; }
    }
}