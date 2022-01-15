using AutoMapper;
using BookApp.Entities;
using BookApp.Entities.Dtos.GenreDtos;

namespace BookApp.Services.AutoMapperProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreAddDto>().ReverseMap();
            CreateMap<Genre, GenreUpdateDto>().ReverseMap();
        }
    }
}
