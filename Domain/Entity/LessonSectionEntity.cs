using System.Collections.Generic;
using System.Linq;
using Domain.Enum;

namespace Domain.Entity
{
    public class LessonSectionEntity
    {
        public long Id { get; set; }
        public long LessonId { get; set; }
        public long QuizId { get; set; }
        public LessonSectionType Type { get; set; }
        public string Text { get; set; }
        public string VideoUrl { get; set; }
        
        public QuizEntity Quiz { get; set; }
        public LessonEntity Lesson { get; set; }
    }
}