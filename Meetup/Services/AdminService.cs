using AutoMapper;
using Meetup.ApplicationDbContext;
using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces;
using Meetup.Interfaces.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Services
{
    public class AdminService : IAdminService
    {
        readonly AppDbContext dbContext;
        readonly IMapper mapper;

        public AdminService(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateMeetupLocation(MeetupLocationDto meetupLocationDto)
        {
            var meetupLocation = mapper.Map<MeetupLocation>(meetupLocationDto);
            meetupLocation.Id = Guid.NewGuid().ToString();
            await dbContext.MeetupLocations.AddAsync(meetupLocation);
            await dbContext.SaveChangesAsync();
        }

        public async Task<MeetupDto> GetMeetupById(string id)
        {
            var meetup = await dbContext.Meetups.Include(p=>p.Users).FirstOrDefaultAsync(p => p.Id == id);
            return mapper.Map<MeetupDto>(meetup);
        }

        public async Task<ICollection<MeetupDto>> GetAllMeetupsAsync()
        {
            var meetups = await dbContext.Meetups.ToListAsync();
            return mapper.Map<ICollection<MeetupDto>>(meetups);
        }

        public async Task<ICollection<UserDto>> GetUsersInMeetupAsync(string id)
        {
            var users = await dbContext.Meetups.Include(p => p.Users).FirstOrDefaultAsync(p => p.Id == id);
            return mapper.Map<ICollection<UserDto>>(users.Users);
        }

        public async Task<ICollection<UserDto>> GetAllUsersAsync()
        {
            var users = await dbContext.Users.Include(p => p.Language).ToListAsync();
            return mapper.Map<ICollection<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await dbContext.Users.Include(p => p.Language).FirstOrDefaultAsync(p => p.Id == id);
            return mapper.Map<UserDto>(user);
        }

        public async Task<MeetupLocationDto> GetMeetupLocationByIdAsync(string id)
        {
            var meetupLocation = mapper.Map<MeetupLocationDto>(await dbContext.MeetupLocations.FirstOrDefaultAsync(p => p.Id == id));
            return meetupLocation;
        }

        public async Task<ICollection<MeetupLocationDto>> GetAllMeetupLocationAsync()
        {
            var meetupLocation = mapper.Map<ICollection<MeetupLocationDto>>(await dbContext.MeetupLocations.Include(p => p.Meetups).ToListAsync());
            return meetupLocation;
        }
    }
}
