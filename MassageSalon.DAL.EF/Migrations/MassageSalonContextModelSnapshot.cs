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
                            Description = "The best masseur",
                            Name = "Makar",
                            Surname = "Sham"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Good masseur",
                            Name = "Bega",
                            Surname = "Dobrov"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The best masseur",
                            Name = "Egor",
                            Surname = "Karas"
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

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TimeRecord")
                        .HasColumnType("datetime2");

                    b.Property<int>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MasseurId");

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
                            Login = "my@gmail.com",
                            Password = "123456",
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

                    b.HasOne("MassageSalon.DAL.Common.Entities.Visitor", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Masseur");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Review", b =>
                {
                    b.HasOne("MassageSalon.DAL.Common.Entities.Masseur", "Masseur")
                        .WithMany()
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
                });

            modelBuilder.Entity("MassageSalon.DAL.Common.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
