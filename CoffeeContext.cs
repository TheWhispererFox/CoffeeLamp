using System;
using System.Collections.Generic;
using System.Text;
using CoffeeLamp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeLamp
{
    class CoffeeContext : DbContext
    {
        public CoffeeContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=CoffeeLamp;Integrated Security=true;MultipleActiveResultSets=True");
        }

        public DbSet<UserRole> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Login);

            modelBuilder.Entity<UserRole>()
                .HasKey(r => r.Role);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleFK)
                .HasPrincipalKey(r => r.Role);
        }
    }
}
