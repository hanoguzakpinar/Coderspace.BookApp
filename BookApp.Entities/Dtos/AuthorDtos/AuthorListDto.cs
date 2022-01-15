using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Shared.Entities;

namespace BookApp.Entities.Dtos.AuthorDtos
{
    public class AuthorListDto : DtoGetBase
    {
        public IList<Author> Authors { get; set; }
    }
}
