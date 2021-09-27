using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MassageSalon.DAL.Common.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MassageSalon.DAL.EF.Contexts
{
    public class MassageSalonContext : DbContext
    {
        public DbSet<Masseur> Masseurs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Log> Logs { get; set; }

        public MassageSalonContext(DbContextOptions<MassageSalonContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Role adminRole = new Role() { Id = 1, Name = "admin" };
            Role visitorRole = new Role() { Id = 2, Name = "user" };
            Visitor adminVisitor = new Visitor() { Id = 1, Login = "admin@gmail.com", Password = "admin", RoleId = adminRole.Id };

            builder.Entity<Role>().HasData(new Role[]
            {
                adminRole,
                visitorRole
            });
            builder.Entity<Visitor>().HasData(new Visitor [] 
            {
                adminVisitor
            });


            builder.Entity<Masseur>().HasData(new Masseur
            {
                Id = 1,
                Name = "Makar",
                Surname = "Sham",
                Description = "The best masseur"
            });

            builder.Entity<Masseur>().HasData(new Masseur
            {
                Id = 2,
                Name = "Bega",
                Surname = "Dobrov",
                Description = "Good masseur"
            });

            builder.Entity<Masseur>().HasData(new Masseur
            {
                Id = 3,
                Name = "Egor",
                Surname = "Karas",
                Description = "The best masseur"
            });

            base.OnModelCreating(builder);
        }

    }
}
