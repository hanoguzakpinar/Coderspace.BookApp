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
