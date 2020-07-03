namespace Domain.Entity.Intermediate
{
    public class UserLessonLikesEntity
    {
        public string UserId { get; set; }
        public long LessonId { get; set; }

        public UserEntity User { get; set; }
        public LessonEntity Lesson { get; set; }
    }
}