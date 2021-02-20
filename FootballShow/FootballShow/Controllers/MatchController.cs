using FootballShow.Models.Repositories;
using FootballShow.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FootballShow.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchRepository _matchRepository;

        public MatchController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public IActionResult Index(int? teamId)
        {
            IEnumerable<MatchIndexViewModel> matches =
                _matchRepository.GetAllMatches().Select(match => new MatchIndexViewModel
                {
                    Id = match.Id,
                    HomeTeam = match.HomeTeam,
                    AwayTeam = match.AwayTeam,
                    HomeTeamGoals = match.HomeTeamGoals,
                    AwayTeamGoals = match.AwayTeamGoals,
                    LocalDate = match.LocalDate,
                    TeamId = match.TeamId,
                    TeamName = match.Team.Name
                });

            if (teamId == null)
            {
                return View(matches);
            }
            else
            {
                ViewBag.Team = matches.First(match => match.TeamId == teamId).TeamName;
                return View(matches.Where(match => match.TeamId == teamId));
            }
        }
    }
}
