namespace Domain.Entity.Intermediate
{
    public class UserCourseLikesEntity
    {
        public string UserId { get; set; }
        public long CourseId { get; set; }

        public UserEntity User { get; set; }
        public CourseEntity Course { get; set; }
    }
}