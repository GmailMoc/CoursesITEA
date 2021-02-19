using System.Collections.Generic;
using System.Linq;

namespace FootballShow.Models.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private FootballShowDbContext _context { get; }

        public MatchRepository(FootballShowDbContext context)
        {
            _context = context;
        }
        
        public void AddLeague(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public IEnumerable<Match> GetAllMatches()
        {
            return _context.Matches.ToList();
        }

        public void RemoveMatch(int matchId)
        {
            _context.Matches.Remove(_context.Matches.First(match => match.Id == matchId));
            _context.SaveChanges();
        }
    }
}
