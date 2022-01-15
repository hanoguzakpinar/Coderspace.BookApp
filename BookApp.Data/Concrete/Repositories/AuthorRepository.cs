using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Data.Abstract;
using BookApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data.Concrete.Repositories
{
    public class AuthorRepository : EntityRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DbContext context) : base(context)
        {
        }
    }
}
