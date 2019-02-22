using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using People.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Data
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<KindService> kindServices { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Residence> Residences { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
