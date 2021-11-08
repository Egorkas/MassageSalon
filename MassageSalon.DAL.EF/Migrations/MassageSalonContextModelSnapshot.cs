﻿// <auto-generated />
using System;
using MassageSalon.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MassageSalon.DAL.EF.Migrations
{
    [DbContext(typeof(MassageSalonContext))]
    partial class MassageSalonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Masseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Masseurs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Masseur with 7 years of experience. Masseur of the 2020 year. Winner of the Masseur's championship 2018, 2020.",
                            Name = "Makar",
                            Surname = "Sham",
                            TitleImagePath = "Makar.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Masseur with 11 years of experience. He successfully ran the London College of Massage for many years. ",
                            Name = "Wendy",
                            Surname = "Kavanagh",
                            TitleImagePath = "Wendy.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Masseur with 14 years of experience. Has Massage Assosiation Sertificate.",
                            Name = "Alex",
                            Surname = "Karas",
                            TitleImagePath = "Alex.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Masseur with 23 years of experience. President and organizer of the European Massage Championship with the New Massage Association which will have its second edition in 2021.As an ex wellness therapist, and holding to the deep belief that massage presents a true benefit for the world, he dedicated the second part of of his massage career to the advancement of all massage techniques and especially, to make sure that the talent of massage therapists be recognized within the wellness community and more broadly with the general public. ",
                            Name = " Julien",
                            Surname = "Elis",
                            TitleImagePath = "Julias.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Description = "U.S. massage therapist won the gold medal in chair massage and a silver medal in overall best massage at the World Championship in Massage 2021 competition in Copenhagen, Denmark.",
                            Name = "Chaz",
                            Surname = "Armstrong",
                            TitleImagePath = "Chaz.jpg"
                        });
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Full body",
                            Price = 40,
                            Title = "Classic massage"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Back and shoulder",
                            Price = 55,
                            Title = "Hot stone massage"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Head and face massage",
                            Price = 43,
                            Title = "Indian head massage"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Foot and legs",
                            Price = 25,
                            Title = "Foot/reflexology massage"
                        });
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MasseurId")
                        .HasColumnType("int");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TimeRecord")
                        .HasColumnType("datetime2");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MasseurId");

                    b.HasIndex("OfferId");

                    b.HasIndex("VisitorId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MasseurId")
                        .HasColumnType("int");

                    b.Property<string>("UserReview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MasseurId");

                    b.HasIndex("VisitorId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        });
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Visitors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "admin@gmail.com",
                            Password = "admin",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Record", b =>
                {
                    b.HasOne("MassageSalon.DAL.Common.Entities.Masseur", "Masseur")
                        .WithMany("Records")
                        .HasForeignKey("MasseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MassageSalon.DAL.Common.Entities.Offer", "Offer")
                        .WithMany()
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MassageSalon.DAL.Common.Entities.Visitor", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Masseur");

                    b.Navigation("Offer");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Review", b =>
                {
                    b.HasOne("MassageSalon.DAL.Common.Entities.Masseur", "Masseur")
                        .WithMany("Reviews")
                        .HasForeignKey("MasseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MassageSalon.DAL.Common.Entities.Visitor", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Masseur");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Visitor", b =>
                {
                    b.HasOne("MassageSalon.DAL.Common.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Masseur", b =>
                {
                    b.Navigation("Records");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
