using Test66bit.Models;

namespace Test66bit.Interfaces.Repos
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllTeamsAsync();
        Team AddTeam(Team team);
        Team FindTeamByName(string name);
    }
}
