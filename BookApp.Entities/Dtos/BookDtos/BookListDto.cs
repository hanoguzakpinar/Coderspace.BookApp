using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Shared.Entities;

namespace BookApp.Entities.Dtos.BookDtos
{
    public class BookListDto : DtoGetBase
    {
        public IList<Book> Books { get; set; }
    }
}
