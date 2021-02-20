using System.Collections.Generic;

namespace FootballShow.Models.Repositories
{
    public interface IMatchRepository
    {
        IEnumerable<Match> GetAllMatches();

        void RemoveMatch(int matchId);

        void AddMatch(Match match);
    }
}
