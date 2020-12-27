using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp_HW5_MVC_db.Models;
using WebApp_HW5_MVC_db.Repositories;

namespace WebApp_HW5_MVC_db.Controllers
{
    public class CountryController : Controller
    {
        private ICountryRepository _countryRepository { get; }

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }


        public IActionResult Index(int id)
        {
            if (id == 0)
                ViewData["Countries"] = _countryRepository.GetAllCountries().ToList();
            else
                ViewData["Countries"] = _countryRepository.GetCountry(id).ToList();

            return View();
        }

        public IActionResult Delete(int id)
        {
            _countryRepository.DeleteCountry(id);
            return RedirectPermanent("Index");
        }

        public IActionResult Modify(int id, int sickCount, int deadCount, int recoveredCount, bool vaccine)
        {
            Country country = _countryRepository.GetCountry(id).First();

            country.SickCount = sickCount;
            country.DeadCount = deadCount;
            country.RecoveredCount = recoveredCount;
            country.Vaccine = vaccine;

            _countryRepository.ModifyCountry(country);

            return RedirectPermanent("Index");
        }

        public IActionResult Create(string name, int population, int sick, int dead, int recovered)
        {
            _countryRepository.CreateCountry(new Country { Name = name, Population = population, SickCount = sick, DeadCount = dead, RecoveredCount = recovered, Vaccine = false });
            return RedirectPermanent("Index");
        }
    }
}
