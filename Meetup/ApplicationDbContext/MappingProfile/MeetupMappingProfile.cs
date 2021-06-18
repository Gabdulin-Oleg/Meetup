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
    public class MeetupMappingProfile : Profile
    {
        public MeetupMappingProfile()
        {
            CreateMap<Meetups, MeetupDto>();
            CreateMap<MeetupDto, Meetups>();

            CreateMap<MeetupViewModel, MeetupDto>()
                .ForMember(p => p.Images, p => p.Ignore());
        }
    }
}
