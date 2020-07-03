namespace Domain.Entity
{
    public class LastVisitedLessonEntity
    {
        public long CourseId { get; set; }
        public string UserId { get; set; }
        public long LessonId { get; set; }
        
        
        public CourseEntity Course { get; set; }
        public UserEntity User { get; set; }
        public LessonEntity Lesson { get; set; }
    }
}