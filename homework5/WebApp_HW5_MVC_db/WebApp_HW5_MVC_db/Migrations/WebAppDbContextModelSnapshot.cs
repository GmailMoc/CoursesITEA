﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp_HW5_MVC_db.Models;

namespace WebApp_HW5_MVC_db.Migrations
{
    [DbContext(typeof(WebAppDbContext))]
    partial class WebAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("WebApp_HW5_MVC_db.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DeadCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.Property<int>("RecoveredCount")
                        .HasColumnType("int");

                    b.Property<int>("SickCount")
                        .HasColumnType("int");

                    b.Property<bool>("Vaccine")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeadCount = 317729,
                            Name = "US",
                            Population = 328200000,
                            RecoveredCount = 16800450,
                            SickCount = 17860634,
                            Vaccine = false
                        },
                        new
                        {
                            Id = 2,
                            DeadCount = 145810,
                            Name = "India",
                            Population = 1353150536,
                            RecoveredCount = 9606111,
                            SickCount = 10055560,
                            Vaccine = false
                        },
                        new
                        {
                            Id = 3,
                            DeadCount = 186764,
                            Name = "Brazil",
                            Population = 209500000,
                            RecoveredCount = 6409986,
                            SickCount = 7238600,
                            Vaccine = false
                        });
                });

            modelBuilder.Entity("WebApp_HW5_MVC_db.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "East",
                            Zone = "Green"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "West",
                            Zone = "Yellow"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Name = "North",
                            Zone = "Red"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 1,
                            Name = "South",
                            Zone = "Yellow"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            Name = "Center",
                            Zone = "Red"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 3,
                            Name = "East",
                            Zone = "Red"
                        },
                        new
                        {
                            Id = 7,
                            CountryId = 2,
                            Name = "West",
                            Zone = "Green"
                        },
                        new
                        {
                            Id = 8,
                            CountryId = 3,
                            Name = "West",
                            Zone = "Red"
                        });
                });

            modelBuilder.Entity("WebApp_HW5_MVC_db.Models.Human", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSick")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Humans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 38,
                            DistrictId = 1,
                            FirstName = "Obi-wan",
                            Gender = "Male",
                            IsSick = false,
                            LastName = "Kenobi"
                        },
                        new
                        {
                            Id = 2,
                            Age = 54,
                            DistrictId = 1,
                            FirstName = "Sanwise",
                            Gender = "Male",
                            IsSick = false,
                            LastName = "Gamgee"
                        },
                        new
                        {
                            Id = 3,
                            Age = 30,
                            DistrictId = 3,
                            FirstName = "Hose",
                            Gender = "Male",
                            IsSick = true,
                            LastName = "Rodriges"
                        },
                        new
                        {
                            Id = 4,
                            Age = 43,
                            DistrictId = 2,
                            FirstName = "Consuela",
                            Gender = "Female",
                            IsSick = false,
                            LastName = "Tridana"
                        },
                        new
                        {
                            Id = 5,
                            Age = 25,
                            DistrictId = 3,
                            FirstName = "Ana",
                            Gender = "Female",
                            IsSick = true,
                            LastName = "Cormelia"
                        },
                        new
                        {
                            Id = 6,
                            Age = 84,
                            DistrictId = 1,
                            FirstName = "Thomas",
                            Gender = "Male",
                            IsSick = true,
                            LastName = "Edison"
                        },
                        new
                        {
                            Id = 7,
                            Age = 32,
                            DistrictId = 1,
                            FirstName = "Alex",
                            Gender = "Male",
                            IsSick = true,
                            LastName = "Circk"
                        },
                        new
                        {
                            Id = 8,
                            Age = 33,
                            DistrictId = 1,
                            FirstName = "James",
                            Gender = "Male",
                            IsSick = true,
                            LastName = "Milner"
                        });
                });

            modelBuilder.Entity("WebApp_HW5_MVC_db.Models.District", b =>
                {
                    b.HasOne("WebApp_HW5_MVC_db.Models.Country", "Country")
                        .WithMany("District")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("WebApp_HW5_MVC_db.Models.Human", b =>
                {
                    b.HasOne("WebApp_HW5_MVC_db.Models.District", "District")
                        .WithMany("Human")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("WebApp_HW5_MVC_db.Models.Country", b =>
                {
                    b.Navigation("District");
                });

            modelBuilder.Entity("WebApp_HW5_MVC_db.Models.District", b =>
                {
                    b.Navigation("Human");
                });
#pragma warning restore 612, 618
        }
    }
}
