using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Models.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();

        void RemoveCountry(int countryId);

        void AddCountry(Country country);
    }
}
