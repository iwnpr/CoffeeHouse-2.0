using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuService.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.Name)
                    .HasMaxLength(120)
                    .IsRequired();

                e.Property(x => x.Description)
                    .HasMaxLength(300);

                e.Property(x => x.Price)
                    .IsRequired();

                e.Property(x => x.Category)
                    .HasConversion<int>();

                e.Property(x => x.Portion)
                    .IsRequired();
            });
        }
    }
}