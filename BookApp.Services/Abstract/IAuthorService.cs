using BookApp.Entities.Dtos.AuthorDtos;
using BookApp.Shared.Results.Abstract;
using System.Threading.Tasks;

namespace BookApp.Services.Abstract
{
    public interface IAuthorService
    {
        Task<IDataResult<AuthorDto>> GetAsync(int authorId);
        Task<IDataResult<AuthorListDto>> GetAllAsync();
        Task<IResult> AddAsync(AuthorAddDto authorAddDto);
        Task<IResult> UpdateAsync(AuthorUpdateDto authorUpdateDto);
        Task<IResult> DeleteAsync(int authorId);
        Task<IDataResult<int>> CountAsync();
    }
}
