using AutoMapper;
using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces.Dtos;
using Meetup.ViewModels;

namespace Meetup.ApplicationDbContext.MappingProfile
{
    public class MeetupLocationMappingProfile : Profile
    {
        public MeetupLocationMappingProfile()
        {
            CreateMap<MeetupLocationViewModel, MeetupLocationDto>();
            CreateMap<MeetupLocationDto, MeetupLocationViewModel>();

            CreateMap<MeetupLocationDto, MeetupLocation>();
            CreateMap<MeetupLocation, MeetupLocationDto>();

            CreateMap<MeetupLocation, MeetupLocationViewModel>();
            CreateMap<MeetupLocationMappingProfile, MeetupLocation>();
        }
    }
}
