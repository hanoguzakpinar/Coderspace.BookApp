using System.Linq;
using BookApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BookApp.Data.Concrete.Contexts;
using BookApp.Entities.Dtos.BookDtos;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly BookContext _context;

        public HomeController(IBookService bookService, BookContext context)
        {
            _bookService = bookService;
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var books = _context.Books.AsQueryable();
            books = books.Include(x => x.Author);

            if (id != null)
            {
                books = books.
                    Include(x => x.Genre).
                    Where(x => x.Genre.Id == id);
            }

            var model = new BookListDto()
            {
                Books = books.ToList()
            };

            return View("Index", model);
        }
    }
}
