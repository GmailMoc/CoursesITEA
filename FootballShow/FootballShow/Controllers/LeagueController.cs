using FootballShow.Models.Repositories;
using FootballShow.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FootballShow.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILeagueRepository _leagueRepository;

        public LeagueController(ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        [AllowAnonymous]
        public IActionResult Index(int? leagueId)
        {
            IEnumerable<LeagueIndexViewModel> leagues =
                _leagueRepository.GetAllLeagues().Select(league => new LeagueIndexViewModel
                {
                    Id = league.Id,
                    Name = league.Name,
                    Country = league.Country,
                    EmblemUrl = league.EmblemUrl
                });


            if (leagueId == null)
            {
                return View(leagues);
            }
            else
            {
                return View(leagues.Where(league => league.Id == leagueId));
            }
        }
    }
}
