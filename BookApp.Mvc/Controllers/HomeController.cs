using BookApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public HomeController(IGenreService genreService, IAuthorService authorService, IBookService bookService)
        {
            _genreService = genreService;
            _authorService = authorService;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            return View(books.Data);
        }
    }
}
