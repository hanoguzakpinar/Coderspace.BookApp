using AutoMapper;
using BookApp.Entities;
using BookApp.Entities.Dtos.BookDtos;

namespace BookApp.Services.AutoMapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookAddDto>().ReverseMap();
            CreateMap<Book, BookUpdateDto>().ReverseMap();
        }
    }
}
