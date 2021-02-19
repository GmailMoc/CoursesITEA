using System.Collections.Generic;

namespace FootballShow.Models.Repositories
{
    public interface ILeagueRepository
    {
        IEnumerable<League> GetAllLeagues();

        void RemoveLeague(int leagueId);

        void AddLeague(League league);
    }
}
