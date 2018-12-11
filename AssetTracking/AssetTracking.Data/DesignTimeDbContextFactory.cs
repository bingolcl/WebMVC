using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AssetTracking.Data
{
    public class DesignTimeDbContextFactory : Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<AssetContext>
    {
        public AssetContext CreateDbContext(string[] args)
        {

            var builder = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<AssetContext>();

            var connectionString = @"Data Source=SERVER03;Initial Catalog=Asset;Trusted_Connection=True;";

            builder.UseSqlServer(connectionString);

            return new AssetContext(builder.Options);
        }
    }
}
