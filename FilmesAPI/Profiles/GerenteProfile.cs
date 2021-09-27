using AutoMapper;
using FilmesAPI.Data.DTOs.Cinema;
using FilmesAPI.Data.DTOs.Gerente;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Models.Gerente>();
            CreateMap<Gerente, UpdateGerenteDto>();
            CreateMap<UpdateGerenteDto, Gerente>();
        }
    }
}
