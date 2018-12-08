using AssetTracking.BLL.interfaces;
using AssetTracking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetTracking.BLL
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddManagerServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("AssetConnection");
            services.AddTransient<IAssetManager, AssetManager>();
            services.AddTransient<IAssetTypeManager, AssetTypeManager>();
            services.AddTransient<IManufacturerManager, ManufacturerManager>();
            services.AddTransient<IModelManager, ModelManager>();
            services.AddDbContext<AssetContext>(options =>
                        options.UseSqlServer(connString));

            return services;
        }
    }
}
