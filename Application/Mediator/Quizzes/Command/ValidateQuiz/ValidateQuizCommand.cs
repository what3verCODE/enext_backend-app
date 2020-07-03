using System.Collections.Generic;
using Application.Common.Mapping;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Mediator.Quizzes.Command.ValidateQuiz
{
    public class ValidateQuizCommand : IRequest<QuizValidationResponse>, IMapFrom<QuizEntity>
    {
        public long Id { get; set; }
        public virtual ICollection<ValidateQuestion> Questions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ValidateQuizCommand, QuizEntity>();
        }

        public class ValidateQuestion : IMapFrom<QuestionEntity>
        {
            public long Id { get; set; }
            public virtual ICollection<ValidateAnswer> Answers { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<ValidateQuestion, QuestionEntity>();
            }
        }
        
        public class ValidateAnswer : IMapFrom<AnswerEntity>
        {
            public long Id { get; set; }
            public bool IsSelected { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<ValidateAnswer, AnswerEntity>();
            }
        }
    }
}