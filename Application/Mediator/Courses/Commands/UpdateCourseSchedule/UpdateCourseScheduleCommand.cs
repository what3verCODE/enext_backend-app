using System.Collections.Generic;
using Application.Common.Mapping;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Mediator.Courses.Commands.UpdateCourseSchedule
{
    public class UpdateCourseScheduleCommand : IRequest<CourseResponse>, IMapFrom<CourseEntity>
    {
        public long Id { get; set; }
        public virtual ICollection<UpdateModule> Modules { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCourseScheduleCommand, CourseEntity>();
        }
        
        public class UpdateModule : IMapFrom<ModuleEntity>
        {
            public long? Id { get; set; }
            public string Title { get; set; }
            public virtual ICollection<UpdateLesson> Lessons { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<UpdateModule, ModuleEntity>();
            }
        }

        public class UpdateLesson : IMapFrom<LessonEntity>
        {
            public long? Id { get; set; }
            public string Title { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<UpdateLesson, LessonEntity>();
            }
        }
    }
}