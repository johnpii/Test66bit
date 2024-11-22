using Test66bit.Interfaces.Repos;
using Test66bit.Interfaces.Services;
using Test66bit.Models;

namespace Test66bit.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await _teamRepository.GetAllTeamsAsync();
        }

        public Team AddTeam(Team team)
        {
            var newTeam = _teamRepository.AddTeam(team);
            return newTeam;
        }

        public Team FindTeamByName(string name)
        {
            return _teamRepository.FindTeamByName(name);
        }
    }

}
