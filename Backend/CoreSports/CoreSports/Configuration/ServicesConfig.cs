using CoreSports.Services;
using CoreSports.Services.Contracts;
using Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace CoreSports.Configuration
{
    public class ServicesConfig
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMappingService, XmlMappingService>();
        }
    }
}
