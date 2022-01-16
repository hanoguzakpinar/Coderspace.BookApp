using BookApp.Data.Abstract;
using BookApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data.Concrete.Repositories
{
    public class GenreRepository : EntityRepository<Genre>,IGenreRepository
    {
        public GenreRepository(DbContext context) : base(context)
        {
        }
    }
}
