using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Shared.Entities;

namespace BookApp.Entities.Dtos.GenreDtos
{
    public class GenreDto : DtoGetBase
    {
        public Genre Genre { get; set; }
    }
}
