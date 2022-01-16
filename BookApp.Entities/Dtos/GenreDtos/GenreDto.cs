using BookApp.Shared.Entities;

namespace BookApp.Entities.Dtos.GenreDtos
{
    public class GenreDto : DtoGetBase
    {
        public Genre Genre { get; set; }
    }
}
