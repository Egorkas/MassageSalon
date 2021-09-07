using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MassageSalon.DAL.Common.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MassageSalon.DAL.EF.Contexts
{
    public class MassageSalonContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Masseur> Masseurs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Record> Records { get; set; }

        public MassageSalonContext(DbContextOptions<MassageSalonContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MassageSalonDb;Trusted_Connection=True;");
            base.OnModelCreating(builder);

            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
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
        }

    }
}
