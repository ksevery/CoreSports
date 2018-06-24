using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreSports.Helpers;
using Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace CoreSports
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            InitializeDatabase(host).Wait();

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        private static async Task InitializeDatabase(IWebHost host)
        {
            using (var serviceScope = host.Services.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();

                if (!db.Users.Any())
                {
                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var adminUser = new ApplicationUser()
                    {
                        Email = "admin@admin.com",
                        UserName = "admin@admin.com"
                    };

                    await userManager.CreateAsync(adminUser, "!SecurePass123");


                    await userManager.AddClaimAsync(adminUser, new Claim(Constants.IdClaim, adminUser.Id));
                    await userManager.AddClaimAsync(adminUser, new Claim(Constants.RoleClaim, Constants.AdminRole));
                }
            }
        }
    }
}
