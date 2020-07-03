namespace Domain.Entity.Intermediate
{
    public class UserCourseEntity
    {
        public string SubscriberId { get; set; }
        public long CourseId { get; set; }

        public UserEntity Subscriber { get; set; }
        public CourseEntity Course { get; set; }
    }
}