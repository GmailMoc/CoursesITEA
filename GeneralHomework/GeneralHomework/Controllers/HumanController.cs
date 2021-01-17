using GeneralHomework.Models;
using GeneralHomework.Models.Repositories;
using GeneralHomework.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GeneralHomework.Controllers
{
    public class HumanController : Controller
    {
        private readonly IHumanRepository _humanRepository;
        private readonly ICountryRepository _countryRepository;

        public HumanController(IHumanRepository humanRepository, ICountryRepository countryRepository)
        {
            _humanRepository = humanRepository;
            _countryRepository = countryRepository;
        }

        public IActionResult Index(int? humanId)
        {
            //соединяем с помощью Join, чтобы не делать несколько запросов к БД одновременно.
            //одновременно было 2 запроса, потому что для каждого человека выбиралось название страны и получалось что мы делали выборку людей и для каждого человека еще выборку названия страны
            IEnumerable<HumanIndexViewModel> humans =
                _humanRepository.GetAllHumans().Join(_countryRepository.GetAllCountries(),
                                                human => human.CountryId,
                                                country => country.Id,
                                                (human, country) => new HumanIndexViewModel 
                                                {
                                                    Id = human.Id,
                                                    FirstName = human.FirstName,
                                                    LastName = human.LastName,
                                                    Age = human.Age,
                                                    CountryName = human.Country.Name,
                                                    CountryId = human.Country.Id
                                                });


            if (humanId == null)
            {
                return View(humans);
            }
            else
            {
                return View(humans.Where(human => human.Id == humanId));
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Human human)
        {
            _humanRepository.AddHuman(human);
            return View();
        }

        public IActionResult Delete(int humanId)
        {
            try
            {
                _humanRepository.RemoveHuman(humanId);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return View();
        }
    }
}
