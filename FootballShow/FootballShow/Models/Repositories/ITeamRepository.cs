using System.Collections.Generic;

namespace FootballShow.Models.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAllTeams();

        void RemoveTeam(int teamId);

        void AddLeague(Team team);
    }
}
