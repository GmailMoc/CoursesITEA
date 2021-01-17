using GeneralHomework.Models;
using GeneralHomework.Models.Repositories;
using GeneralHomework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHumanRepository _humanRepository;
        private readonly ICountryRepository _countryRepository;

        public HomeController(ILogger<HomeController> logger,
            IHumanRepository humanRepository,
            ICountryRepository countryRepository)
        {
            _logger = logger;
            _humanRepository = humanRepository;
            _countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            IEnumerable<Human> humans = _humanRepository.GetAllHumans();
            IEnumerable<Country> countries = _countryRepository.GetAllCountries();
            return View(new HomeInfoViewModel { Humans = humans, Countries = countries });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
