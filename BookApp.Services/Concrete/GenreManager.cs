using AutoMapper;
using BookApp.Data.Abstract;
using BookApp.Entities;
using BookApp.Entities.Dtos.GenreDtos;
using BookApp.Services.Abstract;
using BookApp.Shared.Results.Abstract;
using BookApp.Shared.Results.Concrete;
using BookApp.Shared.Results.Enums;
using System.Threading.Tasks;

namespace BookApp.Services.Concrete
{
    public class GenreManager : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<GenreDto>> GetAsync(int genreId)
        {
            var genre = await _unitOfWork.Genres.GetAsync(g => g.Id == genreId, g => g.Books);
            if (genre is not null)
            {
                return new DataResult<GenreDto>(ResultStatus.Success, new GenreDto()
                {
                    Genre = genre,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<GenreDto>(ResultStatus.Error, "Tür bulunamadı.", null);
        }

        public async Task<IDataResult<GenreListDto>> GetAllAsync()
        {
            var genres = await _unitOfWork.Genres.GetAllAsync(null, g => g.Books);
            if (genres.Count > -1)
            {
                return new DataResult<GenreListDto>(ResultStatus.Success, new GenreListDto()
                {
                    Genres = genres,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<GenreListDto>(ResultStatus.Error, "Türler bulunamadı.", null);
        }

        public async Task<IResult> AddAsync(GenreAddDto genreAddDto)
        {
            var genre = _mapper.Map<Genre>(genreAddDto);
            await _unitOfWork.Genres.AddAsync(genre);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{genre.Name} başarıyla eklendi.");
        }

        public async Task<IResult> UpdateAsync(GenreUpdateDto genreUpdateDto)
        {
            var oldGenre = await _unitOfWork.Genres.GetAsync(g => g.Id == genreUpdateDto.Id);
            if (oldGenre is null)
            {
                return new Result(ResultStatus.Error, $"{genreUpdateDto.Id}'li tür bulunamadı.");
            }

            var genre = _mapper.Map<GenreUpdateDto, Genre>(genreUpdateDto, oldGenre);

            await _unitOfWork.Genres.UpdateAsync(genre);
            await _unitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, $"{genre.Id}'li tür başarıyla güncellendi.");
        }

        public async Task<IResult> DeleteAsync(int genreId)
        {
            var isExist = await _unitOfWork.Genres.AnyAsync(g => g.Id == genreId);
            if (isExist)
            {
                var genre = await _unitOfWork.Genres.GetAsync(g => g.Id == genreId);
                await _unitOfWork.Genres.DeleteAsync(genre);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{genre.Name} başarıyla silindi.");
            }

            return new Result(ResultStatus.Error, $"{genreId}'li tür bulunamadı.");
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var counter = await _unitOfWork.Genres.CountAsync();
            if (counter > -1)
            {
                return new DataResult<int>(ResultStatus.Success, counter);
            }

            return new DataResult<int>(ResultStatus.Error, "Hata oluştu", -1);
        }
    }
}
