namespace Domain.Entity
{
    public class QuizAttempts
    {
        public int AttemptId { get; set; }
        public long ProgressId { get; set; }
        public long QuizId { get; set; }
        public string UserId { get; set; }
        public string Result { get; set; }
        
        public ProgressEntity Progress { get; set; }
        public QuizEntity Quiz { get; set; }
        public UserEntity User { get; set; }
    }
}