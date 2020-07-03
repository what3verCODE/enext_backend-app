using Application.Common.Mapping;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Mediator.Courses.Commands.UpdateCourseInfo
{
    public class UpdateCourseInfoCommand : IRequest<CourseResponse>, IMapFrom<CourseEntity>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string TargetAudience { get; set; }
        public string Charge { get; set; }
        public string Avatar { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCourseInfoCommand, CourseEntity>();
        }
    }
}