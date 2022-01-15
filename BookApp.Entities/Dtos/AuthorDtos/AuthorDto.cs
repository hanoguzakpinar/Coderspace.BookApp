using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Shared.Entities;

namespace BookApp.Entities.Dtos.AuthorDtos
{
    public class AuthorDto : DtoGetBase
    {
        public Author Author { get; set; }
    }
}
