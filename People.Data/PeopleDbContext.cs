using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using People.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace People.Data
{
    public class PeopleDbContext : IdentityDbContext
    {
        public PeopleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<KindService> kindServices { get; set; }
        public DbSet<Residence> Residences { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Province>().HasKey(p => p.Id);
            modelBuilder.Entity<Province>().Property(p => p.Id).UseMySqlIdentityColumn();
            modelBuilder.Entity<Province>().HasData(
               new Province { Id = 1, Name = "Provincia 1" },
               new Province { Id = 2, Name = "Provincia 2" },
               new Province { Id = 3, Name = "Provincia 3" }
           );

            modelBuilder.Entity<City>().HasKey(p => p.Id);
            modelBuilder.Entity<City>().Property(p => p.Id).UseMySqlIdentityColumn();
            modelBuilder.Entity<City>().HasData(
               new City { Id = 1, Name = "Ciudad 1", IdProvince = 1 },
               new City { Id = 2, Name = "Ciudad 2", IdProvince = 2 },
               new City { Id = 3, Name = "Ciudad 3", IdProvince = 3 }
           );

            modelBuilder.Entity<KindService>().HasKey(p => p.Id);
            modelBuilder.Entity<KindService>().Property(p => p.Id).UseMySqlIdentityColumn();
            modelBuilder.Entity<KindService>().HasData(
                new KindService { Id = 1, Name = "Luz" },
                new KindService { Id = 2, Name = "Agua" },
                new KindService { Id = 3, Name = "Entretenimiento" },
                new KindService { Id = 4, Name = "Salud" },
                new KindService { Id = 5, Name = "Estudios" }
            );

            modelBuilder.Entity<Residence>().HasKey(p => p.Id);
            modelBuilder.Entity<Residence>().Property(p => p.Id).UseMySqlIdentityColumn();

            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().Property(p => p.Id).UseMySqlIdentityColumn();
        }
    }
}
