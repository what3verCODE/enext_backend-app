using Application.Common.Mapping;
using AutoMapper;
using Domain.Entity;

namespace Application.Dto
{
    public class ProgressComplexResponse : IMapFrom<ProgressEntity>
    {
        public long Index { get; set; }
        public long Id { get; set; }
        public UserResponse User { get; set; }
        public string ClassName { get; set; }
        public int Progress { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProgressEntity, ProgressComplexResponse>();
        }
    }
}