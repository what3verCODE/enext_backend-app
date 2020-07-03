using System.Collections.Generic;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;

namespace Application.Dto
{
    public class LessonResponse : IMapFrom<LessonEntity>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool ManualChecking { get; set; }
        public virtual ICollection<LessonSectionResponse> Sections { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LessonEntity, LessonResponse>();
        }
    }
    
    public class LessonSectionResponse : IMapFrom<LessonSectionEntity>
    {
        public long Id { get; set; }
        public LessonSectionType Type { get; set; }
        public string Text { get; set; }
        public string VideoUrl { get; set; }
        public QuizResponse Quiz { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LessonSectionEntity, LessonSectionResponse>();
        }
    }
    
    public class QuizResponse : IMapFrom<QuizEntity>
    {
        public long Id { get; set; }
        public int MaxAttempts { get; set; }
        public virtual ICollection<QuestionResponse> Questions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<QuizEntity, QuizResponse>();
        }
    }
    
    public class QuestionResponse : IMapFrom<QuestionEntity>
    {
        public long Id { get; set; }
        public QuestionType Type { get; set; }
        public string Value { get; set; }
        public int Score { get; set; }
        public virtual ICollection<AnswerResponse> Answers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<QuestionEntity, QuestionResponse>();
        }
    }

    public class AnswerResponse : IMapFrom<AnswerEntity>
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public bool IsCorrect { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AnswerEntity, AnswerResponse>();
        }
    }
}