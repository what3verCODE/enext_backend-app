namespace Domain.Entity.Intermediate
{
    public class AuthorCourseEntity
    {
        public string AuthorId { get; set; }
        public long CourseId { get; set; }

        public UserEntity Author { get; set; }
        public CourseEntity Course { get; set; }
    }
}