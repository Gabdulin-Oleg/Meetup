using AutoMapper;
using Meetup.ApplicationDbContext;
using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces;
using Meetup.Interfaces.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<ApplicationUser> userManager;
        readonly SignInManager<ApplicationUser> signInManager;
        readonly IHttpContextAccessor httpContextAccessor;
        readonly AppDbContext dbContext;
        readonly IEmailSender emailService;
        readonly IUrlHelper url;

        readonly IMapper mapper;

        public UserService(UserManager<ApplicationUser> userManager, IEmailSender emailService, AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IUrlHelper url, IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.emailService = emailService;
            this.dbContext = dbContext;
            this.url = url;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
            this.signInManager = signInManager;
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

                await emailService.SendEmailAsync(applicationUser.Email, "Confirm your account",
                    $"Подтвердите регистрацию, перейдя по <a href='{callbackUrl}'>ссылке</a>");

                var user = mapper.Map<User>(userDto);

                user.Id = Guid.NewGuid().ToString();
                await dbContext.Users.AddAsync(user);
                dbContext.Meetups.FirstOrDefault(p => p.Id == "1").Users.Add(user);
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

        public async Task<bool> CreateMeetup(MeetupDto meetupDto)
        {
            var meetupLocation = await dbContext.MeetupLocations.Include(p => p.Meetups).FirstOrDefaultAsync(p => p.Id == meetupDto.MeetupLocationId);

            if (meetupLocation.IsFreeTime)
            {
                var meetup = mapper.Map<Meetups>(meetupDto);
                using MemoryStream memoryStream = new MemoryStream();
                meetupDto.Stream.CopyTo(memoryStream);

                meetup.Images = memoryStream.ToArray();


                meetup.Id = Guid.NewGuid().ToString();
                meetup.Speaker = await dbContext.Users.FirstAsync(p => p.Email == signInManager.Context.User.Identity.Name);
                AddTimeMeetup(meetupLocation, meetup.DurationMeetup);


                dbContext.MeetupLocations.Update(meetupLocation);
                await dbContext.Meetups.AddAsync(meetup);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task SignUpMeetup(string meetupId)
        {
            var meetup = await dbContext.Meetups.FirstOrDefaultAsync(p => p.Id == meetupId);
            var user = await dbContext.Users.Include(p => p.Meetups).FirstOrDefaultAsync(p => p.Email == signInManager.Context.User.Identity.Name);
            if (user.Meetups.FirstOrDefault(p => p.Id == meetup.Id) == null)
            {
                user.Meetups.Add(meetup);
                dbContext.Users.Update(user);
                await dbContext.SaveChangesAsync();
            }

        }
        public async Task<MeetupLocationDto> GetMeetupLocationByIdAsync(string id)
        {
            var meetupLocation = mapper.Map<MeetupLocationDto>(await dbContext.MeetupLocations.FirstOrDefaultAsync(p => p.Id == id));
            return meetupLocation;
        }

        public async Task<ICollection<MeetupLocationDto>> GetAllMeetupLocationAsync()
        {
            var meetupLocation = mapper.Map<ICollection<MeetupLocationDto>>(await dbContext.MeetupLocations.Include(p => p.Meetups).Where(p => p.IsFreeTime).ToListAsync());
            return meetupLocation;
        }

        private MeetupLocation AddTimeMeetup(MeetupLocation meetupLocation, double duration)
        {
            meetupLocation.StartFreeTime = meetupLocation.StartFreeTime.AddHours(duration);
            if (meetupLocation.StartFreeTime >= meetupLocation.EndFreeTime)
            {
                meetupLocation.IsFreeTime = false;
                return meetupLocation;
            }
            return meetupLocation;
        }


    }
}
