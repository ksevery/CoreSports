using Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoreSports
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            InitializeDatabase(host);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        private static void InitializeDatabase(IWebHost host)
        {
            using (var serviceScope = host.Services.CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
            }
        }
    }
}
