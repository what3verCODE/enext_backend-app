using System.Collections.Generic;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;

namespace Application.Dto
{
    public class QuizValidationResponse : IMapFrom<QuizEntity>
    {
        public long Id { get; set; }
        public int MaxAttempts { get; set; }
        public virtual ICollection<QuestionValidationResponse> Questions { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<QuizEntity, QuizValidationResponse>();
        }

        public class QuestionValidationResponse : IMapFrom<QuestionEntity>
        {
            public long Id { get; set; }
            public QuestionType Type { get; set; }
            public string Value { get; set; }
            public int Score { get; set; }
            public virtual ICollection<AnswerValidationResponse> Answers { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<QuestionEntity, QuestionValidationResponse>();
            }
        }
        
        public class AnswerValidationResponse : IMapFrom<AnswerEntity>
        {
            public long Id { get; set; }
            public long QuestionId { get; set; }
            public string Value { get; set; }
            public bool IsSelected { get; set; }
            public bool Wrong { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<AnswerEntity, AnswerValidationResponse>();
            }
        }
    }
}