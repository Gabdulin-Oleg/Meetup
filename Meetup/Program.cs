using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Meetup
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();//.Run();
            using var scope = host.Services.CreateScope();
            await SeedData(scope);
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("https://*:5001", "http://*:5000");
                });

        private static async Task SeedData(IServiceScope serviceScope)
        {
            DataSeet dataSeet = serviceScope.ServiceProvider.GetRequiredService<DataSeet>();
            await dataSeet.SeedData();
        }
    }
}
