using BookApp.Data.Abstract;
using BookApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data.Concrete.Repositories
{
    public class BookRepository : EntityRepository<Book>,IBookRepository
    {
        public BookRepository(DbContext context) : base(context)
        {
        }
    }
}
