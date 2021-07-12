using AutoMapper;
using C_RestApiNet5.Dtos;
using C_RestApiNet5.Models;

namespace C_RestApiNet5.Profiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<CreateFilmDto, Film>();
            CreateMap<UpdateFilmDto, Film>();
            CreateMap<Film, ReadFilmDto>();
        }
    }
}