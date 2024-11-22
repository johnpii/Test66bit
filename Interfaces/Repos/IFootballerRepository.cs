using Test66bit.Models;

namespace Test66bit.Interfaces.Repos
{
    public interface IFootballerRepository
    {
        void AddFootballer(Footballer footballer);
        Task<List<Footballer>> GetAllFootballersAsync();
        void EditFootballer(Footballer footballer);
    }
}
