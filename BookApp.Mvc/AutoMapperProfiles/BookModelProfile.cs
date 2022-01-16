using AutoMapper;
using BookApp.Entities.Dtos.BookDtos;
using BookApp.Mvc.Areas.Admin.Models;

namespace BookApp.Mvc.AutoMapperProfiles
{
    public class BookModelProfile : Profile
    {
        public BookModelProfile()
        {
            CreateMap<BookCreateModel, BookAddDto>().ReverseMap();
            CreateMap<BookUpdateModel, BookUpdateDto>().ReverseMap();
        }
    }
}
