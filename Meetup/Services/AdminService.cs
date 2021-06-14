using Meetup.ApplicationDbContext;
using Meetup.ApplicationDbContext.Model;
using Meetup.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Meetup.Services
{
    public class AdminService : IAdminService
    {
        AppDbContext dbContext;

        public AdminService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<User> GetAllUsers()
        {
            return dbContext.Set<User>().ToArray();
        }

        public User GetUserById(int id)
        {
            var user = dbContext.Set<User>().FirstOrDefault(p => p.Id == id);
            user.Language = dbContext.Set<Language>().Where(p => p.UserId == user.Id).ToArray();
            return user;
        }
    }
}
