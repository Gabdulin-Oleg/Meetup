using Meetup.ApplicationDbContext;
using Meetup.ApplicationDbContext.Model;
using Meetup.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

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
            return dbContext.Set<User>().FirstOrDefault(p => p.Id == id);
        }
    }
}
