using System;
using System.Threading.Tasks;

namespace BookApp.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAuthorRepository Authors { get; }
        IGenreRepository Genres { get; }
        IBookRepository Books { get; }
        Task<int> SaveAsync();
    }
}
