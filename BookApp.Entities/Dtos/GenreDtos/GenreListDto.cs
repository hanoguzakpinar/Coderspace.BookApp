using BookApp.Shared.Entities;
using System.Collections.Generic;

namespace BookApp.Entities.Dtos.GenreDtos
{
    public class GenreListDto : DtoGetBase
    {
        public IList<Genre> Genres { get; set; }
    }
}
