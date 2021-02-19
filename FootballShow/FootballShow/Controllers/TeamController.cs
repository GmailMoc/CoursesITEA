using FootballShow.Models.Repositories;
using FootballShow.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FootballShow.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ILeagueRepository _leagueRepository;

        public TeamController(ITeamRepository teamRepository, ILeagueRepository leagueRepository)
        {
            _teamRepository = teamRepository;
            _leagueRepository = leagueRepository;
        }

        [AllowAnonymous]
        public IActionResult Index(int? leagueId)
        {
            IEnumerable<TeamIndexViewModel> teams =
                _teamRepository.GetAllTeams().Join(_leagueRepository.GetAllLeagues(),
                                                team => team.LeagueId,
                                                league => league.Id,
                                                (team, league) => new TeamIndexViewModel
                                                {
                                                    Id = team.Id,
                                                    Name = team.Name,
                                                    WebSite = team.WebSite,
                                                    Arena = team.Arena,
                                                    League = team.League.Name,
                                                    LeagueId = team.LeagueId
                                                });

            if (leagueId == null)
            {
                return View(teams);
            }
            else
            {
                ViewBag.League = teams.First().League;
                return View(teams.Where(team => team.LeagueId == leagueId));
            }
        }
    }
}
