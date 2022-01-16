using BookApp.Shared.Entities;

namespace BookApp.Entities.Dtos.BookDtos
{
    public class BookDto : DtoGetBase
    {
        public Book Book { get; set; }
    }
}
