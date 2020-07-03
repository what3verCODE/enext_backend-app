using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;

namespace Application.Dto
{
    public class CourseResponse : IMapFrom<CourseEntity>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string TargetAudience { get; set; }
        public string Charge { get; set; }
        public string Avatar { get; set; }
        public CourseStatus Status { get; set; }
        public int Likes { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public virtual ICollection<ModuleWithoutSections> Modules { get; set; }
        public virtual ICollection<UserResponse> Authors { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CourseEntity, CourseResponse>()
                .ForMember(dest => dest.Authors,
                    options => 
                        options.MapFrom(x => 
                            x.Authors.Select(y => y.Author).ToList()))
                .ForMember(dest => dest.Likes,
                    options => options.MapFrom(x => x.UsersLikes.Count));
        }
    }
    
    public class ModuleWithoutSections : IMapFrom<ModuleEntity>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<LessonWithoutSections> Lessons { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ModuleEntity, ModuleWithoutSections>();
        }
    }
    
    public class LessonWithoutSections : IMapFrom<LessonEntity>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool ManualChecking { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LessonEntity, LessonWithoutSections>();
        }
    }
}