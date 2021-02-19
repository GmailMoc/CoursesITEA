using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace FootballShow.Models
{
    public class FootballShowDbContext : IdentityDbContext<CustomIdentityUser>
    {
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }

        public FootballShowDbContext(DbContextOptions<FootballShowDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // для того, чтобы не заполнять данными снова

            modelBuilder.Entity<League>().HasData(
                new League { Id = 2002, Name = "Bundesliga", Country = "Germany", EmblemUrl = "" },
                new League { Id = 2021, Name = "Premier League", Country = "England", EmblemUrl = "" });

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "1. FC Koln", Arena = "RheinEnergieSTADION", WebSite = "http://www.fc-koeln.de", LeagueId = 2002 },
                new Team { Id = 5, Name = "FC Bayern Munchen", Arena = "Allianz Arena", WebSite = "http://www.fcbayern.de", LeagueId = 2002 },
                new Team { Id = 57, Name = "Arsenal FC", Arena = "Emirates Stadium", WebSite = "http://www.arsenal.com", LeagueId = 2021 },
                new Team { Id = 61, Name = "Chelsea FC", Arena = "Stamford Bridge", WebSite = "http://www.chelseafc.com", LeagueId = 2021 });

            modelBuilder.Entity<Match>().HasData(
                new Match { Id = 1, HomeTeam = "Eintracht Frankfurt", AwayTeam = "1. FC Koln", HomeTeamGoals = 2, AwayTeamGoals = 0, 
                    LocalDate = DateTime.Parse("2021-02-14T14:30:00Z"), TeamWinner = "Eintracht Frankfurt", TeamId = 1 },

                new Match { Id = 2, HomeTeam = "FC Bayern München", AwayTeam = "Arminia Bielefeld", HomeTeamGoals = 3, AwayTeamGoals = 3, 
                    LocalDate = DateTime.Parse("2021-02-15T19:30:00Z"), TeamWinner = "DRAW", TeamId = 5 },

                new Match { Id = 3, HomeTeam = "Arsenal FC", AwayTeam = "Leeds United FC", HomeTeamGoals = 4, AwayTeamGoals = 2, 
                    LocalDate = DateTime.Parse("2021-02-14T16:30:00Z"), TeamWinner = "Arsenal FC", TeamId = 57 },

                new Match { Id = 4, HomeTeam = "Chelsea FC", AwayTeam = "Newcastle United FC", HomeTeamGoals = 2, AwayTeamGoals = 0, 
                    LocalDate = DateTime.Parse("2021-02-15T20:00:00Z"), TeamWinner = "Chelsea FC", TeamId = 61 });
        }
    }
}
