using Microsoft.EntityFrameworkCore;
using System;
using CPRG102.Rentals.Domain;

namespace CPRG102.Rentals.Data
{
    public class RentalsContext : DbContext
    {
        //I have removed the constructor as it involves Dependency Injection--I will tackle this in a future module
        //We will instead work with the DbContextOptionsBuilder in the OnConfiguring method

        public DbSet<RentalProperty> Rentals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change the connection string here for your home computer
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=RentalProperties;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data created here
            modelBuilder.Entity<RentalProperty>().HasData(
                new RentalProperty { Id = 1, Address = "1345 - 670 14th Ave SW", City = "Calgary", Province = "AB", PostalCode = "T3T 3T3", Rent = 1200m },
                new RentalProperty { Id = 2, Address = "4567 66th Ave NW", City = "Calgary", Province = "AB", PostalCode = "T2T 2D2", Rent = 2400m },
                new RentalProperty { Id = 3, Address = "240 - 2111 4th St NW", City = "Calgary", Province = "AB", PostalCode = "T5T 5T5", Rent = 1800m }
                );
        }
    }
}
