using AutoMapper;
using BookApp.Data.Abstract;
using BookApp.Entities;
using BookApp.Entities.Dtos.BookDtos;
using BookApp.Services.Abstract;
using BookApp.Shared.Results.Abstract;
using BookApp.Shared.Results.Concrete;
using BookApp.Shared.Results.Enums;
using System.Threading.Tasks;

namespace BookApp.Services.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<BookDto>> GetAsync(int bookId)
        {
            var book = await _unitOfWork.Books.GetAsync(b => b.Id == bookId, b => b.Genre, b => b.Author);
            if (book is not null)
            {
                return new DataResult<BookDto>(ResultStatus.Success, new BookDto()
                {
                    Book = book,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<BookDto>(ResultStatus.Error, $"Kitap bulunamadı.", null);
        }

        public async Task<IDataResult<BookListDto>> GetAllAsync()
        {
            var books = await _unitOfWork.Books.GetAllAsync(null, b => b.Genre, b => b.Author);
            if (books.Count > -1)
            {
                return new DataResult<BookListDto>(ResultStatus.Success, new BookListDto()
                {
                    Books = books,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<BookListDto>(ResultStatus.Error, "Kitaplar bulunamadı.", null);
        }

        public async Task<IDataResult<BookListDto>> GetAllByAuthorAsync(int authorId)
        {
            var author = await _unitOfWork.Authors.AnyAsync(a => a.Id == authorId);
            if (author)
            {
                var books = await _unitOfWork.Books.GetAllAsync(b => b.AuthorID == authorId, b => b.Author, b => b.Genre);
                if (books.Count > -1)
                {
                    return new DataResult<BookListDto>(ResultStatus.Success, new BookListDto()
                    {
                        Books = books,
                        ResultStatus = ResultStatus.Success
                    });
                }

                return new DataResult<BookListDto>(ResultStatus.Error, $"Kitaplar bulunamadı.", null);
            }
            return new DataResult<BookListDto>(ResultStatus.Error, $"Yazar bulunamadı.", null);
        }

        public async Task<IResult> AddAsync(BookAddDto bookAddDto)
        {
            var book = _mapper.Map<Book>(bookAddDto);

            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{book.Title} başarıyla eklendi.");
        }

        public async Task<IResult> UpdateAsync(BookUpdateDto bookUpdateDto)
        {
            var oldBook = await _unitOfWork.Books.GetAsync(b => b.Id == bookUpdateDto.Id);
            if (oldBook is null)
            {
                return new Result(ResultStatus.Error, $"{bookUpdateDto.Id}'li kitap bulunamadı.");
            }

            var book = _mapper.Map<BookUpdateDto, Book>(bookUpdateDto, oldBook);

            await _unitOfWork.Books.UpdateAsync(book);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{book.Id}'li kitap başarıyla güncellendi");
        }

        public async Task<IResult> DeleteAsync(int bookId)
        {
            var book = await _unitOfWork.Books.GetAsync(b => b.Id == bookId);
            if (book is not null)
            {
                await _unitOfWork.Books.DeleteAsync(book);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{bookId}'li kitap başarıyla silindi.");
            }

            return new Result(ResultStatus.Error, $"{bookId}'li kitap bulunamadı.");
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var counter = await _unitOfWork.Books.CountAsync();
            if (counter > -1)
            {
                return new DataResult<int>(ResultStatus.Success, counter);
            }

            return new DataResult<int>(ResultStatus.Error, "Hata oluştu", -1);
        }
    }
}
