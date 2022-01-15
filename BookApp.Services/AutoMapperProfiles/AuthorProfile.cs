using AutoMapper;
using BookApp.Entities;
using BookApp.Entities.Dtos.AuthorDtos;

namespace BookApp.Services.AutoMapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorAddDto>().ReverseMap();
            CreateMap<Author, AuthorUpdateDto>().ReverseMap();
        }
    }
}
