using Test66bit.Interfaces.Repos;
using Test66bit.Interfaces.Services;
using Test66bit.Models;

namespace Test66bit.Services
{
    public class FootballerService : IFootballerService
    {
        private readonly IFootballerRepository _footballerRepository;
        private readonly ITeamRepository _teamRepository;
        public FootballerService(IFootballerRepository footballerRepository, ITeamRepository teamRepository)
        {
            _footballerRepository = footballerRepository;
            _teamRepository = teamRepository;
        }

        public void AddFootballer(Footballer footballer)
        {
            _footballerRepository.AddFootballer(footballer);
        }

        public async Task<List<Footballer>> GetAllFootballersAsync()
        {
            return await _footballerRepository.GetAllFootballersAsync();
        }

        public void EditFootballer(Footballer footballer)
        {
            _footballerRepository.EditFootballer(footballer);
        }
    }
}
