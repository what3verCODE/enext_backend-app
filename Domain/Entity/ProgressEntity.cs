using System.Collections.Generic;
using System.Dynamic;
using System.Security.Cryptography;
using Domain.Entity.Intermediate;

namespace Domain.Entity
{
    public class ProgressEntity
    {
        public long Id { get; set; }
        public long LessonId { get; set; }
        public long CourseId { get; set; }
        public string UserId { get; set; }
        public int Score { get; set; }
        public bool IsVisited { get; set; }
        public bool ManuallyChecked { get; set; }
        
        public virtual ICollection<QuizAttempts> Attempts { get; set; }

        public CourseEntity Course { get; set; }
        public LessonEntity Lesson { get; set; }
        public UserEntity User { get; set; }
    }
}