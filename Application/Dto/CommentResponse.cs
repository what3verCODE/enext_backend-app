using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entity;

namespace Application.Dto
{
    public class CommentResponse : IMapFrom<CommentEntity>
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public UserResponse Author { get; set; }
        public DateTime WrittenAt { get; set; }
        public int Likes { get; set; }
        
        public virtual ICollection<CommentResponse> Replies { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CommentEntity, CommentResponse>()
                .ForMember(dest => dest.Likes,
                    options =>
                        options.MapFrom(x => x.UsersLikes.Count))
                .ForMember(dest => dest.Replies,
                    options => 
                        options.MapFrom(x => x.Replies));
        }
    }
}
