using AutoMapper;
using FilmesAPI.Data.DTOs.Cinema;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Models.Cinema>();
            CreateMap<Cinema, UpdateCinemaDto>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
