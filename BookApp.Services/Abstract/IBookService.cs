using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Entities.Dtos.BookDtos;
using BookApp.Shared.Results.Abstract;

namespace BookApp.Services.Abstract
{
    public interface IBookService
    {
        Task<IDataResult<BookDto>> GetAsync(int bookId);
        Task<IDataResult<BookUpdateDto>> GetBookUpdateDtoAsync(int bookId);
        Task<IDataResult<BookListDto>> GetAllAsync();
        Task<IDataResult<BookListDto>> GetAllByAuthorAsync(int authorId);
        Task<IResult> AddAsync(BookAddDto bookAddDto, int userId);
        Task<IResult> UpdateAsync(BookUpdateDto bookUpdateDto);
        Task<IResult> DeleteAsync(int bookId);
        Task<IDataResult<int>> CountAsync();
    }
}
