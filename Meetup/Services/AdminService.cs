using AutoMapper;
using Meetup.ApplicationDbContext;
using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces;
using Meetup.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<ICollection<UserViewModel>> GetUsersInMeetupAsync(string id)
        {
            var users = await dbContext.Meetups.Include(p => p.Users).FirstOrDefaultAsync(p => p.Id == id);

            return mapper.Map<ICollection<UserViewModel>>(users.Users);
        }

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            return await dbContext.Users.Include(p => p.Language).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await dbContext.Users.Include(p => p.Language).FirstOrDefaultAsync(p => p.Id == id);
            return user;
        }
    }
}
