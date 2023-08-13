using DagemovMVC.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DagemovMVC.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
       // public DbSet<Service> Phones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique();
            //modelBuilder.Entity<Pet>().HasIndex("Id", "UserId").IsUnique();
           // modelBuilder.Entity<Phone>().HasIndex(c => c.PhoneNumber).IsUnique();
        }

    }
}
