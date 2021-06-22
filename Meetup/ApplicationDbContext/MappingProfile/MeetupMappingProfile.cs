using AutoMapper;
using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces.Dtos;
using Meetup.ViewModels;

namespace Meetup.ApplicationDbContext.MappingProfile
{
    public class MeetupMappingProfile : Profile
    {
        public MeetupMappingProfile()
        {
            CreateMap<Meetups, MeetupViewModel>();
                //.ForMember(p => p.Images, p => p.Ignore());
            CreateMap<MeetupViewModel, Meetups>()
                .ForMember(p => p.Images, p => p.Ignore());

            CreateMap<Meetups, MeetupDto>();
            CreateMap<MeetupDto, Meetups>();
            CreateMap<MeetupViewModel, MeetupDto>()
                .ForMember(p => p.Stream, p => p.MapFrom(p => p.Images.OpenReadStream()));
        }
    }
}
