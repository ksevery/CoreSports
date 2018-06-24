using System;
using CoreSports.Auth;
using Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Services.Email;

namespace CoreSports.Configuration
{
    public class ServicesConfig
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IJwtFactory, JwtFactory>();
        }
    }
}
