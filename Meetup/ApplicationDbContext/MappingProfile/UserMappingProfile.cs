using AutoMapper;
using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces.Dtos;
using Meetup.ViewModels;

namespace Meetup.ApplicationDbContext.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserViewModel, UserDto>();

            CreateMap<UserDto, RegistredViewModel>();
            CreateMap<RegistredViewModel, UserDto>();

            CreateMap<UserDto, ApplicationUser>()
                .ForMember(p => p.Email, p => p.MapFrom(p => p.Email))
                .ForMember(p => p.UserName, p => p.MapFrom(p => p.Email));
        }
    }
}
