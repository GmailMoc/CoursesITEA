using System.Collections.Generic;
using System.Linq;
using WebApp_HW5_MVC_db.Models;

namespace WebApp_HW5_MVC_db.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private WebAppDbContext _context { get; }

        public CountryRepository(WebAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries;
        }

        public IEnumerable<Country> GetCountry(int id)
        {
            return _context.Countries.Where(Country => Country.Id == id);
        }

        public void CreateCountry(Country Country)
        {
            _context.Add(Country);
            _context.SaveChanges();
        }

        public void ModifyCountry(Country Country)
        {
            _context.Update(Country);
            _context.SaveChanges();
        }

        public void DeleteCountry(int id)
        {
            _context.Countries.Remove(_context.Countries.First(Country => Country.Id == id));
            _context.SaveChanges();
        }
    }
}
