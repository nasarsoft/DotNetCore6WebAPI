using AutoMapper;
using WebApplication3.Dto;
using WebApplication3.Models.Pokemon;

namespace WebApplication3.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
