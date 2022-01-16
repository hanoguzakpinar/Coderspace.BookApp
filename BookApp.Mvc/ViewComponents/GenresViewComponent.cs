using System.Linq;
using BookApp.Data.Concrete.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly BookContext _context;
        public GenresViewComponent(BookContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData.Values["id"];
            return View(_context.Genres.ToList());
        }
    }
}
