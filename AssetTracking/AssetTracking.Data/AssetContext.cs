using AssetTracking.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace AssetTracking.Data
{
    public class AssetContext : DbContext
    {
        //Add-Migration asset-init
        //Update-Database
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }

        public AssetContext(DbContextOptions<AssetContext> options)
   : base(options)
        { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //Change the connection string here for your home computer/lab computer
        //    optionsBuilder.UseSqlServer(@"Server=localhost;Database=Asset;user id=sa;password=SQLPassword;");
        //    //optionsBuilder.UseSqlServer(@"Data Source=SERVER03;Initial Catalog=Domain;Trusted_Connection=True;");
        //    //optionsBuilder.UseSqlServer(@"Data Source=BINGOLCL\\SQLEXPRESS;Initial Catalog=Domain;Trusted_Connection=True;");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data created here
            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Desktop PC" },
                new AssetType { Id = 2, Name = "Laptop" },
                new AssetType { Id = 3, Name = "Tablet" },
                new AssetType { Id = 4, Name = "Monitor" },
                new AssetType { Id = 5, Name = "Mobile Phone" },
                new AssetType { Id = 6, Name = "Desk Phone" }
                );
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Dell" },
                new Manufacturer { Id = 2, Name = "HP" },
                new Manufacturer { Id = 3, Name = "Acer" },
                new Manufacturer { Id = 4, Name = "Apple" },
                new Manufacturer { Id = 5, Name = "Samsung" },
                new Manufacturer { Id = 6, Name = "LG" },
                new Manufacturer { Id = 7, Name = "Avaya" },
                new Manufacturer { Id = 8, Name = "Polycom" },
                new Manufacturer { Id = 9, Name = "Cisco" }
                );

            modelBuilder.Entity<Model>().HasData(
                new Model
                {
                    Id = 1,
                    Name = "Inspiron",
                    ManufacturerId = 1
                },
                new Model
                {
                    Id = 2,
                    Name = "XPS",
                    ManufacturerId = 1
                },
                new Model
                {
                    Id = 3,
                    Name = "Elite",
                    ManufacturerId = 2
                },
                new Model
                {
                    Id = 4,
                    Name = "Aspire",
                    ManufacturerId = 3
                },
                new Model
                {
                    Id = 5,
                    Name = "Latitude E4550",
                    ManufacturerId = 1
                },
                new Model
                {
                    Id = 6,
                    Name = "Latitude E5550",
                    ManufacturerId = 1
                },
                new Model
                {
                    Id = 7,
                    Name = "MacBook Air",
                    ManufacturerId = 4
                },
                new Model
                {
                    Id = 8,
                    Name = "MacBook Pro",
                    ManufacturerId = 4
                },
                new Model
                {
                    Id = 9,
                    Name = "iPad mini",
                    ManufacturerId = 4
                },
                new Model
                {
                    Id = 10,
                    Name = "iPad Air",
                    ManufacturerId = 4
                },
                new Model
                {
                    Id = 11,
                    Name = "Galaxy Tab3",
                    ManufacturerId = 5
                },
                new Model
                {
                    Id = 12,
                    Name = "S200",
                    ManufacturerId = 3
                },
                new Model
                {
                    Id = 13,
                    Name = "STQ414",
                    ManufacturerId = 3
                },
                new Model
                {
                    Id = 14,
                    Name = "22MP",
                    ManufacturerId = 6
                },
                new Model
                {
                    Id = 15,
                    Name = "Pavilion",
                    ManufacturerId = 2
                },
                new Model
                {
                    Id = 16,
                    Name = "iPhone 5",
                    ManufacturerId = 4
                },
                new Model
                {
                    Id = 17,
                    Name = "iPhone 6",
                    ManufacturerId = 4
                },
                new Model
                {
                    Id = 18,
                    Name = "Galaxy S4",
                    ManufacturerId = 5
                },
                new Model
                {
                    Id = 19,
                    Name = "Galaxy S5",
                    ManufacturerId = 5
                },
                new Model
                {
                    Id = 20,
                    Name = "Galaxy Note5",
                    ManufacturerId = 5
                },
                new Model
                {
                    Id = 21,
                    Name = "9612G",
                    ManufacturerId = 7
                },
                new Model
                {
                    Id = 22,
                    Name = "SoundPoint 331",
                    ManufacturerId = 8
                },
                new Model
                {
                    Id = 23,
                    Name = "SPA525G2",
                    ManufacturerId = 9
                });
            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    Id = 1,
                    TagNumber = "Z396",
                    AssetTypeId = 1,
                    ModelId = 1,
                    Description = "Office Computer",
                    AssignedTo = "DO1001",
                    SerialNumber = "X821908-014"
                },
                new Asset
                {
                    Id = 2,
                    TagNumber = "H591",
                    AssetTypeId = 1,
                    ModelId = 2,
                    Description = "Office2 Computer",
                    AssignedTo = "CA1002",
                    SerialNumber = "X821908-080"
                },
                new Asset
                {
                    Id = 3,
                    TagNumber = "P655",
                    AssetTypeId = 2,
                    ModelId = 5,
                    Description = "HR laptop",
                    AssignedTo = "SM1003",
                    SerialNumber = "X85981-254"
                });
        }
    }
}
