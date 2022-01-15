using System.Threading.Tasks;
using BookApp.Entities.Dtos.GenreDtos;
using BookApp.Services.Abstract;
using BookApp.Shared.Results.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var genres = await _genreService.GetAllAsync();
            return View(genres.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GenreAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _genreService.AddAsync(dto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return RedirectToAction("Index", "Genre");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }

            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _genreService.DeleteAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return RedirectToAction("Index", "Genre");
            }
            else
            {
                // refactoring
                return RedirectToAction("Index", "Genre");
            }
        }
    }
}
