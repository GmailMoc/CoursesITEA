using System.Collections.Generic;
using System.Linq;

namespace FootballShow.Models.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private FootballShowDbContext _context { get; }

        public TeamRepository(FootballShowDbContext context)
        {
            _context = context;
        }
        
        public void AddTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _context.Teams.ToList();
        }

        public void RemoveTeam(int teamId)
        {
            _context.Teams.Remove(_context.Teams.First(match => match.Id == teamId));
            _context.SaveChanges();
        }
    }
}
