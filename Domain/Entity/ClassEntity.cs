using System.Collections.Generic;
using Domain.Entity.Intermediate;

namespace Domain.Entity
{
    public class ClassEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string TeacherId { get; set; }

        public TeacherClassEntity Teacher { get; set; }
        public virtual ICollection<StudentClassEntity> Students { get; set; }
        public virtual ICollection<CourseClassEntity> Courses { get; set; }
    }
}