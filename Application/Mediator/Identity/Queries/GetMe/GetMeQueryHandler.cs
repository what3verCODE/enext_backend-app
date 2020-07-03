using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Mediator.Identity.Queries.GetMe
{
    public class GetMeQueryHandler : IRequestHandler<GetMeQuery, UserResponse>
    {
        private readonly UserManager<UserEntity> _manager;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;
        
        public GetMeQueryHandler(ICurrentUserService currentUser, IMapper mapper, UserManager<UserEntity> manager)
        {
            _currentUser = currentUser;
            _mapper = mapper;
            _manager = manager;
        }

        public async Task<UserResponse> Handle(GetMeQuery request, CancellationToken cancellationToken)
        {
            var entity = await _manager.FindByIdAsync(_currentUser.UserId);
            
            if(entity == null)
                throw new System.NotImplementedException();

            return _mapper.Map<UserEntity, UserResponse>(entity);
        }
    }
}