using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using eAppointmentServer.Infrastructure.Repositories;
using eAppointmentServer.Infrastructure.Services;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;


namespace eAppointmentServer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            Env.Load();
            var connectionStringTemplate = configuration.GetConnectionString("SqlServer");
            var dbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";

            var finalConnectionString = connectionStringTemplate
                .Replace("${DB_SERVER}", dbServer);

            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(connectionStringTemplate);
            });

            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequiredLength = 1;
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());


            services.Scan(action =>
            {
                action.FromAssemblies(typeof(DependencyInjection).Assembly)
                .AddClasses(publicOnly: false)
                .UsingRegistrationStrategy(registrationStrategy: Scrutor.RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });


            return services;
        }
    }
}
