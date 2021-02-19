﻿// <auto-generated />
using System;
using FootballShow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballShow.Migrations
{
    [DbContext(typeof(FootballShowDbContext))]
    [Migration("20210219192222_initial migration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FootballShow.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmblemUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Leagues");

                    b.HasData(
                        new
                        {
                            Id = 2002,
                            Country = "Germany",
                            EmblemUrl = "",
                            Name = "Bundesliga"
                        },
                        new
                        {
                            Id = 2021,
                            Country = "England",
                            EmblemUrl = "",
                            Name = "Premier League"
                        });
                });

            modelBuilder.Entity("FootballShow.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AwayTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AwayTeamGoals")
                        .HasColumnType("int");

                    b.Property<string>("HomeTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeTeamGoals")
                        .HasColumnType("int");

                    b.Property<DateTime>("LocalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("TeamWinner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Matches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AwayTeam = "1. FC Koln",
                            AwayTeamGoals = 0,
                            HomeTeam = "Eintracht Frankfurt",
                            HomeTeamGoals = 2,
                            LocalDate = new DateTime(2021, 2, 14, 16, 30, 0, 0, DateTimeKind.Local),
                            TeamId = 1,
                            TeamWinner = "Eintracht Frankfurt"
                        },
                        new
                        {
                            Id = 2,
                            AwayTeam = "Arminia Bielefeld",
                            AwayTeamGoals = 3,
                            HomeTeam = "FC Bayern München",
                            HomeTeamGoals = 3,
                            LocalDate = new DateTime(2021, 2, 15, 21, 30, 0, 0, DateTimeKind.Local),
                            TeamId = 5,
                            TeamWinner = "DRAW"
                        },
                        new
                        {
                            Id = 3,
                            AwayTeam = "",
                            AwayTeamGoals = 2,
                            HomeTeam = "Arsenal FC",
                            HomeTeamGoals = 4,
                            LocalDate = new DateTime(2021, 2, 14, 18, 30, 0, 0, DateTimeKind.Local),
                            TeamId = 57,
                            TeamWinner = "Arsenal FC"
                        },
                        new
                        {
                            Id = 4,
                            AwayTeam = "Newcastle United FC",
                            AwayTeamGoals = 0,
                            HomeTeam = "Chelsea FC",
                            HomeTeamGoals = 2,
                            LocalDate = new DateTime(2021, 2, 15, 22, 0, 0, 0, DateTimeKind.Local),
                            TeamId = 61,
                            TeamWinner = "Chelsea FC"
                        });
                });

            modelBuilder.Entity("FootballShow.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Arena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Arena = "RheinEnergieSTADION",
                            LeagueId = 2002,
                            Name = "1. FC Koln",
                            WebSite = "http://www.fc-koeln.de"
                        },
                        new
                        {
                            Id = 5,
                            Arena = "Allianz Arena",
                            LeagueId = 2002,
                            Name = "FC Bayern Munchen",
                            WebSite = "http://www.fcbayern.de"
                        },
                        new
                        {
                            Id = 57,
                            Arena = "Emirates Stadium",
                            LeagueId = 2021,
                            Name = "Arsenal FC",
                            WebSite = "http://www.arsenal.com"
                        },
                        new
                        {
                            Id = 61,
                            Arena = "Stamford Bridge",
                            LeagueId = 2021,
                            Name = "Chelsea FC",
                            WebSite = "http://www.chelseafc.com"
                        });
                });

            modelBuilder.Entity("FootballShow.Models.Match", b =>
                {
                    b.HasOne("FootballShow.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FootballShow.Models.Team", b =>
                {
                    b.HasOne("FootballShow.Models.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });
#pragma warning restore 612, 618
        }
    }
}
