using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Data.Abstract;
using BookApp.Data.Concrete.Contexts;
using BookApp.Data.Concrete.Repositories;

namespace BookApp.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookContext _context;
        private AuthorRepository _authorRepository;
        private GenreRepository _genreRepository;
        private BookRepository _bookRepository;

        public UnitOfWork(BookContext context)
        {
            _context = context;
        }
        public IAuthorRepository Authors => _authorRepository ?? new AuthorRepository(_context);
        public IGenreRepository Genres => _genreRepository ?? new GenreRepository(_context);
        public IBookRepository Books => _bookRepository ?? new BookRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
