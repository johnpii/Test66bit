using Microsoft.EntityFrameworkCore;
using Test66bit.Data;
using Test66bit.Interfaces.Repos;
using Test66bit.Models;

namespace Test66bit.Repositories
{
    public class FootballerRepository : IFootballerRepository
    {
        private readonly ApplicationDbContext _context;
        public FootballerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddFootballer(Footballer footballer)
        {
            _context.Footballers.Add(footballer);
            _context.SaveChanges();
        }

        public async Task<List<Footballer>> GetAllFootballersAsync()
        {
            return await _context.Footballers.Include(f => f.Team).OrderBy(f => f.Id).ToListAsync();
        }

        public void EditFootballer(Footballer footballer)
        {
            _context.Footballers.Update(footballer);
            _context.SaveChanges();
        }
    }
}
