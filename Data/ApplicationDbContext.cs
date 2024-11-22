using Microsoft.EntityFrameworkCore;
using Test66bit.Models;

namespace Test66bit.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
