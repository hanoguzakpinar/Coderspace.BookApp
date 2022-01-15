using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Entities.Dtos.AuthorDtos;
using BookApp.Shared.Results.Abstract;

namespace BookApp.Services.Abstract
{
    public interface IAuthorService
    {
        Task<IDataResult<AuthorDto>> GetAsync(int authorId);
        Task<IDataResult<AuthorUpdateDto>> GetAuthorUpdateDtoAsync(int authorId);
        Task<IDataResult<AuthorListDto>> GetAllAsync();
        Task<IResult> AddAsync(AuthorAddDto authorAddDto, int userId);
        Task<IResult> UpdateAsync(AuthorUpdateDto authorUpdateDto);
        Task<IResult> DeleteAsync(int authorId);
        Task<IDataResult<int>> CountAsync();
    }
}
