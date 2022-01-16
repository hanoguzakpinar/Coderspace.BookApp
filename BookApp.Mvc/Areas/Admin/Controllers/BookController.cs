using System.Threading.Tasks;
using AutoMapper;
using BookApp.Entities.Dtos.BookDtos;
using BookApp.Mvc.Areas.Admin.Models;
using BookApp.Services.Abstract;
using BookApp.Shared.Results.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IGenreService genreService, IAuthorService authorService, IMapper mapper)
        {
            _bookService = bookService;
            _genreService = genreService;
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            return View(books.Data);
        }

        public async Task<IActionResult> Create()
        {
            var genres = await _genreService.GetAllAsync();
            var authors = await _authorService.GetAllAsync();
            return View(new BookCreateModel()
            {
                Genres = genres.Data.Genres,
                Authors = authors.Data.Authors
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<BookAddDto>(model);

                var result = await _bookService.AddAsync(book);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            var genres = await _genreService.GetAllAsync();
            var authors = await _authorService.GetAllAsync();
            return View(new BookCreateModel()
            {
                Genres = genres.Data.Genres,
                Authors = authors.Data.Authors
            });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return RedirectToAction("Index", "Book");
            }
            else
            {
                // refactoring
                return RedirectToAction("Index", "Book");
            }
        }
    }
}
