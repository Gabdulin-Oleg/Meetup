using AutoMapper;
using Meetup.ApplicationDbContext;
using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces;
using Meetup.Interfaces.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<ApplicationUser> userManager;
        readonly IHttpContextAccessor httpContextAccessor;
        readonly AppDbContext dbContext;
        readonly IEmailSender emailService;
        readonly IUrlHelper url;

        readonly IMapper mapper;

        public UserService(UserManager<ApplicationUser> userManager, IEmailSender emailService, AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IUrlHelper url, IMapper mapper)
        {
            this.userManager = userManager;
            this.emailService = emailService;
            this.dbContext = dbContext;
            this.url = url;

            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }

        public async Task<bool> RegistrationAsync(UserDto userDto)
        {
            var applicationUser = mapper.Map<ApplicationUser>(userDto);
            applicationUser.Id = Guid.NewGuid().ToString();

            var result = await userManager.CreateAsync(applicationUser, userDto.Password);
            if (result.Succeeded)
            {
                var code = await userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                string callbackUrl = url.Action("ConfirmationEmail", "User",
                  new { userId = applicationUser.Id, code = code }, httpContextAccessor.HttpContext.Request.Scheme, httpContextAccessor.HttpContext.Request.Host.Value);

                //await emailService.SendEmailAsync(applicationUser.Email, "Confirm your account",
                //    $"Подтвердите регистрацию, перейдя по <a href='{callbackUrl}'>ссылке</a>");

                var user = mapper.Map<User>(userDto);
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
                dbContext.Meetups.FirstOrDefault(p => p.Id == 2).Users.Add(user);// meetupId);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ConfirmationEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return false;
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);
                return true;
            }
            return false;
        }
    }
}
