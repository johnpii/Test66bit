using AutoMapper;
using Test66bit.Models;
using Test66bit.ViewModels;

namespace Test66bit.Profiles
{
    public class FootballerAddToFootballerMappingProfile : Profile
    {
        public FootballerAddToFootballerMappingProfile()
        {
            CreateMap<FootballerAdd, Footballer>().ReverseMap()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name));
        }
    }
}
