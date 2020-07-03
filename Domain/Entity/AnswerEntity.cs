namespace Domain.Entity
{
    public class AnswerEntity
    {
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public string Value { get; set; }
        public bool IsCorrect { get; set; }

        public QuestionEntity Question { get; set; }
    }
}