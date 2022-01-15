using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
