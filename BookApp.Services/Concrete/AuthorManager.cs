using AutoMapper;
using BookApp.Data.Abstract;
using BookApp.Entities;
using BookApp.Entities.Dtos.AuthorDtos;
using BookApp.Services.Abstract;
using BookApp.Shared.Results.Abstract;
using BookApp.Shared.Results.Concrete;
using BookApp.Shared.Results.Enums;
using System;
using System.Threading.Tasks;

namespace BookApp.Services.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<AuthorDto>> GetAsync(int authorId)
        {
            var author = await _unitOfWork.Authors.GetAsync(g => g.Id == authorId, g => g.Books);
            if (author is not null)
            {
                return new DataResult<AuthorDto>(ResultStatus.Success, new AuthorDto()
                {
                    Author = author,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<AuthorDto>(ResultStatus.Error, "Yazar bulunamadı.", null);
        }

        public async Task<IDataResult<AuthorListDto>> GetAllAsync()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync(null, g => g.Books);
            if (authors.Count > -1)
            {
                return new DataResult<AuthorListDto>(ResultStatus.Success, new AuthorListDto()
                {
                    Authors = authors,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<AuthorListDto>(ResultStatus.Error, "Yazarlar bulunamadı.", null);
        }

        public async Task<IResult> AddAsync(AuthorAddDto authorAddDto)
        {
            var author = _mapper.Map<Author>(authorAddDto);

            await _unitOfWork.Authors.AddAsync(author);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{author.Name + " " + author.Surname} yazar başarıyla eklendi.");
        }

        public async Task<IResult> UpdateAsync(AuthorUpdateDto authorUpdateDto)
        {
            var oldAuthor = await _unitOfWork.Authors.GetAsync(a => a.Id == authorUpdateDto.Id);
            if (oldAuthor is null)
            {
                return new Result(ResultStatus.Error, $"{authorUpdateDto.Id}'li yazar bulunamadı.");
            }

            var author = _mapper.Map<AuthorUpdateDto, Author>(authorUpdateDto, oldAuthor);

            await _unitOfWork.Authors.UpdateAsync(author);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{author.Id}'li yazar başarıyla güncellendi.");

        }

        public async Task<IResult> DeleteAsync(int authorId)
        {
            var author = await _unitOfWork.Authors.GetAsync(a => a.Id == authorId);
            if (author is not null)
            {
                await _unitOfWork.Authors.DeleteAsync(author);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{authorId}'li yazar başarıyla silindi.");
            }

            return new Result(ResultStatus.Error, $"{authorId}'li yazar bulunamadı");
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var counter = await _unitOfWork.Authors.CountAsync();
            if (counter > -1)
            {
                return new DataResult<int>(ResultStatus.Success, counter);
            }

            return new DataResult<int>(ResultStatus.Error, "Hata oluştu", -1);
        }
    }
}
