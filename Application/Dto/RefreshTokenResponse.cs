using Application.Common.Mapping;
using AutoMapper;
using Domain.Entity.Common;

namespace Application.Dto
{
    public class RefreshTokenResponse : IMapFrom<RefreshTokenEntity>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string TokenExpirationTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RefreshTokenEntity, RefreshTokenResponse>();
        }
    }
}