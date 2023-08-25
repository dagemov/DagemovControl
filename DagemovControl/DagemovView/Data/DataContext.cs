﻿using DagemovView.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DagemovView.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
            public DbSet<Adress> Adresses { get; set; }
            public DbSet<Country> Countries { get; set; }
            public DbSet<City> Cities { get; set; }
            public DbSet<State> States { get; set; }
            public DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }

    }
}
