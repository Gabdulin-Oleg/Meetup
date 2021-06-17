using AutoMapper;
using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces.Dtos;
using Meetup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            CreateMap<UserDto, RegistredViewModel>();
            CreateMap<RegistredViewModel, UserDto>();

            CreateMap<UserDto, ApplicationUser>()
                .ForMember(p => p.Email, p => p.MapFrom(p => p.Email))
                .ForMember(p => p.UserName, p => p.MapFrom(p => p.Email));
        }
    }
}
