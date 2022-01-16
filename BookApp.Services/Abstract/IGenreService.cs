using BookApp.Entities.Dtos.GenreDtos;
using BookApp.Shared.Results.Abstract;
using System.Threading.Tasks;

namespace BookApp.Services.Abstract
{
    public interface IGenreService
    {
        Task<IDataResult<GenreDto>> GetAsync(int genreId);
        Task<IDataResult<GenreListDto>> GetAllAsync();
        Task<IResult> AddAsync(GenreAddDto genreAddDto);
        Task<IResult> UpdateAsync(GenreUpdateDto genreUpdateDto);
        Task<IResult> DeleteAsync(int genreId);
        Task<IDataResult<int>> CountAsync();
    }
}
