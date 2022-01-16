using BookApp.Shared.Entities;
using System.Collections.Generic;

namespace BookApp.Entities.Dtos.BookDtos
{
    public class BookListDto : DtoGetBase
    {
        public IList<Book> Books { get; set; }
    }
}
