using System.Collections.Generic;
using System.Linq;

namespace FootballShow.Models.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private FootballShowDbContext _context { get; }

        public LeagueRepository(FootballShowDbContext context)
        {
            _context = context;
        }

        public void AddLeague(League league)
        {
            _context.Leagues.Add(league);
            _context.SaveChanges();
        }

        public IEnumerable<League> GetAllLeagues()
        {
            return _context.Leagues.ToList();
        }

        public void RemoveLeague(int leagueId)
        {
            _context.Leagues.Remove(_context.Leagues.First(human => human.Id == leagueId));
            _context.SaveChanges();
        }
    }
}
