using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralHomework.Models.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public GeneralDbContext _context { get; set; }
        public CountryRepository(GeneralDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public void AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public void RemoveCountry(int countryId)
        {
            throw new NotImplementedException();
        }
    }
}
