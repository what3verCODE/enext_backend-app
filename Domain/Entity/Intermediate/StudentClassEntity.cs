namespace Domain.Entity.Intermediate
{
    public class StudentClassEntity
    {
        public string StudentId { get; set; }
        public long ClassId { get; set; }

        public UserEntity Student { get; set; }
        public ClassEntity Class { get; set; }
    }
}