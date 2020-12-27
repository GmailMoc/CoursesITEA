using System.Collections.Generic;
using WebApp_HW5_MVC_db.Models;

namespace WebApp_HW5_MVC_db.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();

        IEnumerable<Country> GetCountry(int id);

        void CreateCountry(Country Country);

        void ModifyCountry(Country Country);

        void DeleteCountry(int id);
    }
}
