using AutoMapper;
using Users.Application.Dtos;
using Users.Domain.Entities;

namespace Users.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
