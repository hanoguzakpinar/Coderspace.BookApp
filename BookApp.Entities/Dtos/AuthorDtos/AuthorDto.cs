using BookApp.Shared.Entities;

namespace BookApp.Entities.Dtos.AuthorDtos
{
    public class AuthorDto : DtoGetBase
    {
        public Author Author { get; set; }
    }
}
