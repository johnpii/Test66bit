using Microsoft.EntityFrameworkCore;
using Test66bit.Data;
using Test66bit.Interfaces.Repos;
using Test66bit.Models;

namespace Test66bit.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public Team AddTeam(Team team)
        {
            Team newTeam = _context.Teams.Add(team).Entity;
            _context.SaveChanges();
            return newTeam;
        }

        public Team FindTeamByName(string name)
        {
            return _context.Teams.FirstOrDefault(a => a.Name == name);
        }
    }
}
