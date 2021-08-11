using AspNetCore.IServiceCollection.AddIUrlHelper;
using Meetup.ApplicationDbContext;
using Meetup.ApplicationDbContext.Model;
using Meetup.Interfaces;
using Meetup.Services;
using Meetup.Services.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Reflection;

namespace Meetup
{
    public class Startup
    {
        public IWebHostEnvironment Env { get; }
        private const string AllowedDomainsCorsPolicy = "AllowedDomains";
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddUrlHelper();
            services.AddHttpContextAccessor();
            services.AddDbContext<Identity>((sp, option) => option.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AppDbContext>((sp, option) => option.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Meetup", Version = "v1" });
            });
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IUserService, UserService>();
            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<Identity>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);
            services.Configure<EmailOptions>(Configuration.GetSection("EmailOptions"));
            services.Configure<AdminOption>(Configuration.GetSection("Admin"));
            services.AddScoped<DataSeet>();
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");
            services.AddCors();//(ConfigureCors);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meetup v1"));
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseCors(builder => builder.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
        }
        private void ConfigureCors(CorsOptions options)
        {
            options.AddPolicy(AllowedDomainsCorsPolicy, builder =>
            {
                var tokenValidIssuers = new List<string>(Configuration.GetSection($"IdentityServer:TokenValidationParameters:ValidIssuers").Get<string[]>());
                if (Env.IsDevelopment())
                {
                    tokenValidIssuers.Add("http://localhost:3000");
                }
                builder.WithOrigins(tokenValidIssuers.ToArray()).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            });
        }
    }
}
