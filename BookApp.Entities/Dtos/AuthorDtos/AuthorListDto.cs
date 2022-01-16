using BookApp.Shared.Entities;
using System.Collections.Generic;

namespace BookApp.Entities.Dtos.AuthorDtos
{
    public class AuthorListDto : DtoGetBase
    {
        public IList<Author> Authors { get; set; }
    }
}
