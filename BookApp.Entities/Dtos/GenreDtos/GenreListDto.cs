using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Shared.Entities;

namespace BookApp.Entities.Dtos.GenreDtos
{
    public class GenreListDto : DtoGetBase
    {
        public IList<Genre> Genres { get; set; }
    }
}
