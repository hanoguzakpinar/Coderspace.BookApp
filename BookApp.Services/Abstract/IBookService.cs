using BookApp.Entities.Dtos.BookDtos;
using BookApp.Shared.Results.Abstract;
using System.Threading.Tasks;

namespace BookApp.Services.Abstract
{
    public interface IBookService
    {
        Task<IDataResult<BookDto>> GetAsync(int bookId);
        Task<IDataResult<BookListDto>> GetAllAsync();
        Task<IDataResult<BookListDto>> GetAllByAuthorAsync(int authorId);
        Task<IResult> AddAsync(BookAddDto bookAddDto);
        Task<IResult> UpdateAsync(BookUpdateDto bookUpdateDto);
        Task<IResult> DeleteAsync(int bookId);
        Task<IDataResult<int>> CountAsync();
    }
}
