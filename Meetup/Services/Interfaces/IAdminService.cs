using Meetup.ApplicationDbContext.Model;
using System.Collections.Generic;

namespace Meetup.Services.Interfaces
{
    public interface IAdminService
    {
        ICollection<User> GetAllUsers();
        User GetUserById(int id);
    }
}