using System.Collections.Generic;
using Application.Common.Mapping;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using MediatR;

namespace Application.Mediator.Lessons.Commands.UpdateLesson
{
    public class UpdateLessonCommand : IRequest<LessonResponse>, IMapFrom<LessonEntity>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<UpdateSection> Sections { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateLessonCommand, LessonEntity>();
        }

        public class UpdateSection : IMapFrom<LessonSectionEntity>
        {
            public long? Id { get; set; }
            public LessonSectionType Type { get; set; }
            public string Text { get; set; }
            public string VideoUrl { get; set; }
            public UpdateQuiz? Quiz { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<UpdateSection, LessonSectionEntity>();
            }
        }

        public class UpdateQuiz : IMapFrom<QuizEntity>
        {
            public long? Id { get; set; }
            public int MaxAttempts { get; set; }
            public virtual ICollection<UpdateQuestion> Questions { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<UpdateQuiz, QuizEntity>();
            }
        }

        public class UpdateQuestion : IMapFrom<QuestionEntity>
        {
            public long? Id { get; set; }
            public QuestionType Type { get; set; }
            public string Value { get; set; }
            public int Score { get; set; }
            public virtual ICollection<UpdateAnswer> Answers { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<UpdateQuestion, QuestionEntity>();
            }
        }

        public class UpdateAnswer : IMapFrom<AnswerEntity>
        {
            public long? Id { get; set; }
            public string Value { get; set; }
            public bool IsCorrect { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<UpdateAnswer, AnswerEntity>();
            }
        }
    }
}