using Test66bit.Models;

namespace Test66bit.Interfaces.Services
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllTeamsAsync();

        Team AddTeam(Team team);

        Team FindTeamByName(string name);
    }
}
