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
        public DbSet<Offer> Offers { get; set; }
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
            builder.Entity<Visitor>().HasData(new Visitor[]
            {
                adminVisitor
            });

            #region AddMasseurs
            builder.Entity<Masseur>().HasData(new Masseur
            {
                Id = 1,
                Name = "Makar",
                Surname = "Sham",
                Description = "Masseur with 7 years of experience. Masseur of the 2020 year. Winner of the Masseur's championship 2018, 2020.",
                TitleImagePath = "Makar.jpg"
            });

            builder.Entity<Masseur>().HasData(new Masseur
            {
                Id = 2,
                Name = "Wendy",
                Surname = "Kavanagh",
                Description = "Masseur with 11 years of experience. He successfully ran the London College of Massage for many years. ",
                TitleImagePath = "Wendy.jpg"
            });

            builder.Entity<Masseur>().HasData(new Masseur
            {
                Id = 3,
                Name = "Alex",
                Surname = "Karas",
                Description = "Masseur with 14 years of experience. Has Massage Assosiation Sertificate.",
                TitleImagePath = "Alex.jpg"
            });
            builder.Entity<Masseur>().HasData(new Masseur
            {
                Id = 4,
                Name = " Julien",
                Surname = "Elis",
                Description = "Masseur with 23 years of experience. President and organizer of the European Massage Championship with the New Massage Association which will have its second edition in 2021." +
                "As an ex wellness therapist, and holding to the deep belief that massage presents a true benefit for the world," +
                " he dedicated the second part of of his massage career to the advancement of all massage techniques and especially," +
                " to make sure that the talent of massage therapists be recognized within the wellness community and more broadly with the general public. ",
                TitleImagePath = "Julias.jpg"
            });
            builder.Entity<Masseur>().HasData(new Masseur
            {
                Id = 5,
                Name = "Chaz",
                Surname = "Armstrong",
                Description = "U.S. massage therapist won the gold medal in chair massage " +
                "and a silver medal in overall best massage at the World Championship in Massage 2021 competition in Copenhagen, Denmark.",
                TitleImagePath = "Chaz.jpg"
            });
            #endregion

            //add offers
            builder.Entity<Offer>().HasData(new Offer
            {
                Id = 1,
                Title = "Classic massage",
                Description = "Full body",
                Price = 40
            });

            builder.Entity<Offer>().HasData(new Offer
            {
                Id = 2,
                Title = "Hot stone massage",
                Description = "Back and shoulder",
                Price = 55
            });

            builder.Entity<Offer>().HasData(new Offer
            {
                Id = 3,
                Title = "Indian head massage",
                Description = "Head and face massage",
                Price = 43
            });

            builder.Entity<Offer>().HasData(new Offer
            {
                Id = 4 ,
                Title = "Foot/reflexology massage",
                Description = "Foot and legs",
                Price = 25
            });
            base.OnModelCreating(builder);
        }

    }
}
