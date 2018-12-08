using AssetTracking.API.BLL.interfaces;
using AssetTracking.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracking.API.BLL
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddManagerServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("HRConnection");
            services.AddTransient<IEmployeeManager, EmployeeManager>();
            //services.AddTransient<IRentalsManager, RentalsManager>();
            services.AddDbContext<HRContext>(options =>
                        options.UseSqlServer(connString));

            return services;
        }
    }
}
