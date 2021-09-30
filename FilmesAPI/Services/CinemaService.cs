using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Data.DTOs.Cinema;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto adicionaCinema(CreateCinemaDto cinemaDto)
        {
            Models.Cinema cinema = _mapper.Map<Models.Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperarCinemas(string nomeFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (cinemas == null)
                return null;
            else
            {
                if (!string.IsNullOrEmpty(nomeFilme))
                {
                    IEnumerable<Cinema> query = from cinema in cinemas
                                                where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeFilme)
                                                select cinema;
                    cinemas = query.ToList();
                }

                return _mapper.Map<List<ReadCinemaDto>>(cinemas);
            }

        }

        public ReadCinemaDto RecuperarCinemaPorId(int id)
        {
            Models.Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return cinemaDto;
            }

            return null;
        }

        public Result AlterarCinema(int id, UpdateCinemaDto cinemaNovo)
        {
            Models.Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema == null)
                return Result.Fail("Cinema não encontrado");

            _mapper.Map(cinemaNovo, cinema);

            _context.SaveChanges();
            return Result.Ok();
        }

        public Result ApagarCinema(int id)
        {
            Models.Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema == null)
                return Result.Fail("Cinema não encontrado");

            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
