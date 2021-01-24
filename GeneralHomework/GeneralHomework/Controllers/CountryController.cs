using GeneralHomework.Models;
using GeneralHomework.Models.Repositories;
using GeneralHomework.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GeneralHomework.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [AllowAnonymous]
        public IActionResult Index(int? countryId)
        {
            IEnumerable<Country> countries = _countryRepository.GetAllCountries();

            if (countryId == null)
            {
                return View(countries.Select(
                    country => new CountryIndexViewModel
                    {
                        Id = country.Id,
                        NameCountry = country.Name,
                        SickCount = country.SickCount,
                        DeadCount = country.DeadCount,
                        RecoveredCount = country.RecoveredCount
                    }).ToList());
            }
            else
            {
                return View(countries.Where(country => country.Id == countryId).Select(
                    country => new CountryIndexViewModel
                    {
                        Id = country.Id,
                        NameCountry = country.Name,
                        SickCount = country.SickCount,
                        DeadCount = country.DeadCount,
                        RecoveredCount = country.RecoveredCount
                    }).ToList());
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            _countryRepository.AddCountry(country);
            return View();
        }

    }
}
