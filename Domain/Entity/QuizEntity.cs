using System.Collections.Generic;

namespace Domain.Entity
{
    public class QuizEntity
    {
        public long Id { get; set; }
        public long SectionId { get; set; }
        public int MaxAttempts { get; set; }
        public virtual ICollection<QuestionEntity> Questions { get; set; }
        public virtual ICollection<QuizAttempts> Attempts { get; set; }
        public LessonSectionEntity Section { get; set; }
        
    }
}