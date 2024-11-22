using AutoMapper;
using Test66bit.Models;
using Test66bit.ViewModels;

namespace Test66bit.Profiles
{
    public class FootballerEditToFootballerMappingProfile : Profile
    {
        public FootballerEditToFootballerMappingProfile()
        {
            CreateMap<FootballerEdit, Footballer>().ReverseMap()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name));
        }
    }
}
