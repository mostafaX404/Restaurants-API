using Microsoft.EntityFrameworkCore;
using Resturants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Infrastructure.Presistence
{
    internal class ResturantDbContext : DbContext
    {

        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {
        }

        internal DbSet<Resturant> Resturants { get; set; }
        internal DbSet<Dish> Dishes { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resturant>().OwnsOne(x => x.Address);

            modelBuilder.Entity<Resturant>().HasMany(r => r.Dishes).WithOne()
                .HasForeignKey(x => x.RestueantId);

        }

        
    }
}
