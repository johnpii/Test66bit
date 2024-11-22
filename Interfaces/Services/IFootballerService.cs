using Test66bit.Models;

namespace Test66bit.Interfaces.Services
{
    public interface IFootballerService
    {
        void AddFootballer(Footballer footballer);
        Task<List<Footballer>> GetAllFootballersAsync();
        void EditFootballer(Footballer footballer);
    }
}
