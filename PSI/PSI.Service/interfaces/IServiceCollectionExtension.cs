using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI.Service.interfaces
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddManagerServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("PSIConnection");
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITechService, TechService>();
            services.AddDbContext<PSIDevContext>(options =>
                        options.UseSqlServer(connString));

            return services;
        }
    }
}
