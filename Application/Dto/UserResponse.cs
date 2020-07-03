using Application.Common.Mapping;
using AutoMapper;
using Domain.Entity;

namespace Application.Dto
{
    public class UserResponse : IMapFrom<UserEntity>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserEntity, UserResponse>();
        }
    }
}