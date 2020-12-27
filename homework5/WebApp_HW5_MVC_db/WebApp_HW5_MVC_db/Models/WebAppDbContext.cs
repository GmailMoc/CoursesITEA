using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApp_HW5_MVC_db.Models
{
    public class WebAppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Human> Humans { get; set; }

        private IConfiguration _configuration { get; }


        public WebAppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("WebAppDbContext")).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "US", Population = 328200000, SickCount = 17860634, DeadCount = 317729, RecoveredCount = 16800450, Vaccine = false },
                new Country { Id = 2, Name = "India", Population = 1353150536, SickCount = 10055560, DeadCount = 145810, RecoveredCount = 9606111, Vaccine = false },
                new Country { Id = 3, Name = "Brazil", Population = 209500000, SickCount = 7238600, DeadCount = 186764, RecoveredCount = 6409986, Vaccine = false });

            modelBuilder.Entity<District>().HasData(
                new District { Id = 1, Name = "East", Zone = "Green", CountryId = 1 },
                new District { Id = 2, Name = "West", Zone = "Yellow", CountryId = 1 },
                new District { Id = 3, Name = "North", Zone = "Red", CountryId = 1 },
                new District { Id = 4, Name = "South", Zone = "Yellow", CountryId = 1 },
                new District { Id = 5, Name = "Center", Zone = "Red", CountryId = 2 },
                new District { Id = 6, Name = "East", Zone = "Red", CountryId = 3 },
                new District { Id = 7, Name = "West", Zone = "Green", CountryId = 2 },
                new District { Id = 8, Name = "West", Zone = "Red", CountryId = 3 });

            modelBuilder.Entity<Human>().HasData(
                new Human { Id = 1, FirstName = "Obi-wan", LastName = "Kenobi", Age = 38, IsSick = false, Gender = "Male", DistrictId = 1 },
                new Human { Id = 2, FirstName = "Sanwise", LastName = "Gamgee", Age = 54, IsSick = false, Gender = "Male", DistrictId = 2 },
                new Human { Id = 3, FirstName = "Hose", LastName = "Rodriges", Age = 30, IsSick = true, Gender = "Male", DistrictId = 3 },
                new Human { Id = 4, FirstName = "Consuela", LastName = "Tridana", Age = 43, IsSick = false, Gender = "Female", DistrictId = 4 },
                new Human { Id = 5, FirstName = "Ana", LastName = "Cormelia", Age = 25, IsSick = true, Gender = "Female", DistrictId = 5 },
                new Human { Id = 6, FirstName = "Thomas", LastName = "Edison", Age = 84, IsSick = true, Gender = "Male", DistrictId = 6 },
                new Human { Id = 7, FirstName = "Alex", LastName = "Circk", Age = 32, IsSick = true, Gender = "Male", DistrictId = 7 },
                new Human { Id = 8, FirstName = "James", LastName = "Milner", Age = 33, IsSick = true, Gender = "Male", DistrictId = 8 });
        }
    }
}
