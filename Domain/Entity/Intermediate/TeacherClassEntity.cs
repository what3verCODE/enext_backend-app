namespace Domain.Entity.Intermediate
{
    public class TeacherClassEntity
    {
        public string TeacherId { get; set; }
        public long ClassId { get; set; }

        public UserEntity Teacher { get; set; }
        public ClassEntity Class { get; set; }
    }
}