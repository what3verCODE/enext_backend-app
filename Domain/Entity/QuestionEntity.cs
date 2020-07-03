using System.Collections.Generic;
using Domain.Enum;

namespace Domain.Entity
{
    public class QuestionEntity
    {
        public long Id { get; set; }
        public long QuizId { get; set; }
        public QuestionType Type { get; set; }
        public string Value { get; set; }
        public int Score { get; set; }

        public ICollection<AnswerEntity> Answers { get; set; } = new List<AnswerEntity>();
        public QuizEntity Quiz { get; set; }
    }
}