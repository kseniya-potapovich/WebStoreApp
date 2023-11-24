using AutoMapper;
using WebStoreApp.Dto;
using WedStoreApp.Entities;

namespace WebStoreApp.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}
