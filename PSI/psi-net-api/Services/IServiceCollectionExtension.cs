using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using psi_net_api.Models;
using psi_net_api.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psi_net_api.Services
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddManagerServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("PSIConnection");
            services.AddTransient<IEmployeeManager, EmployeeManager>();
            services.AddTransient<IUserManager, UserManager>();
            //services.AddTransient<IRentalsManager, RentalsManager>();
            services.AddDbContext<PSIContext>(options =>
                        options.UseSqlServer(connString));

            return services;
        }
    }
}
