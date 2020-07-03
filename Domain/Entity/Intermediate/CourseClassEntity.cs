namespace Domain.Entity.Intermediate
{
    public class CourseClassEntity
    {
        public long CourseId { get; set; }
        public long ClassId { get; set; }

        public CourseEntity Course { get; set; }
        public ClassEntity Class { get; set; }
    }
}