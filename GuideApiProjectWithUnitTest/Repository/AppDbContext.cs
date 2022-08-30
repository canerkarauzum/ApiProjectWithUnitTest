using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Price).IsRequired().HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Product>().Property(x => x.Color).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Stock).IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
