using System.Linq;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entity;

namespace Application.Dto
{
    public class ProgressResponse : IMapFrom<ProgressEntity>
    {
        public long Id { get; set; }
        public UserResponse User { get; set; }
        public LessonResponse Lesson { get; set; }
        public int Score { get; set; }
        public bool IsVisited { get; set; }
        public bool ManuallyChecked { get; set; }
        public int AttemptsCount { get; set; }
        public string[] AttemptsResult { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProgressEntity, ProgressResponse>()
                .ForMember(dest => dest.AttemptsCount,
                    options 
                        => options.MapFrom(x 
                            => x.Attempts.Count))
                .ForMember(dest => dest.AttemptsResult,
                    options 
                        => options.MapFrom(x 
                            => x.Attempts.Select(y => y.Result)));
        }
    }
}