using GeneralHomework.Models;
using GeneralHomework.Models.Repositories;
using GeneralHomework.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

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

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Info()
        {
            IEnumerable<Human> humans = _humanRepository.GetAllHumans();
            IEnumerable<Country> countries = _countryRepository.GetAllCountries();
            return View(new HomeInfoViewModel { Humans = humans, Countries = countries });
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
