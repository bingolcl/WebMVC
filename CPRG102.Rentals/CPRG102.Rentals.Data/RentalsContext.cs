using Microsoft.EntityFrameworkCore;
using System;
using CPRG102.Rentals.Domain;

namespace CPRG102.Rentals.Data
{
    public class RentalsContext : DbContext
    {
        //public RentalsContext(DbContextOptions<RentalsContext> options)
        //    : base(options)
        //{
        //}

        public RentalsContext()
    : base()
        {
        }
        public DbSet<RentalProperty>  Rentals { get; set; }
    }
}
