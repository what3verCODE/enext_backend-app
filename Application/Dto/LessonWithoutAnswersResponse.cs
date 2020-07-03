using System.Collections.Generic;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;

namespace Application.Dto
{
    public class LessonWithoutAnswersResponse : IMapFrom<LessonEntity>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool ManualChecking { get; set; }
        public virtual ICollection<LessonSectionWithoutAnswers> Sections { get; set; }
        public virtual ICollection<CommentResponse> Comments { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LessonEntity, LessonWithoutAnswersResponse>();
        }
    }

    public class LessonSectionWithoutAnswers : IMapFrom<LessonSectionEntity>
    {
        public long Id { get; set; }
        public LessonSectionType Type { get; set; }
        public string Text { get; set; }
        public string VideoUrl { get; set; }
        public QuizWithoutAnswers Quiz { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LessonSectionEntity, LessonSectionWithoutAnswers>();
        }
    }

    public class QuizWithoutAnswers : IMapFrom<QuizEntity>
    {
        public long Id { get; set; }
        public int MaxAttempts { get; set; }
        public virtual ICollection<QuestionWithoutAnswers> Questions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<QuizEntity, QuizWithoutAnswers>();
        }
    }

    public class QuestionWithoutAnswers : IMapFrom<QuestionEntity>
    {
        public long Id { get; set; }
        public QuestionType Type { get; set; }
        public string Value { get; set; }
        public int Score { get; set; }
        public virtual ICollection<AnswerWithoutAnswers> Answers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<QuestionEntity, QuestionWithoutAnswers>();
        }
    }

    public class AnswerWithoutAnswers : IMapFrom<AnswerEntity>
    {
        public long Id { get; set; }
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AnswerEntity, AnswerWithoutAnswers>();
        }
    }
}