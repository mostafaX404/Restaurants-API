using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resturants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Infrastructure.Presistence
{
    public class ResturantDbContext : IdentityDbContext<AppUser>
    {

        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {
        }

        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Dish> Dishes { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Resturant>().OwnsOne(x => x.Address);

            modelBuilder.Entity<Resturant>().HasMany(r => r.Dishes).WithOne()
                .HasForeignKey(x => x.RestueantId);

            modelBuilder.Entity<AppUser>()
                .HasMany(o=>o.OwndeResturants)
                .WithOne(r=>r.Owner)
                .HasForeignKey(r=>r.OwnerId);

        }

        
    }
}
