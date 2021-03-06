using System.Threading.Tasks;
using BookApp.Entities.Dtos.AuthorDtos;
using BookApp.Services.Abstract;
using BookApp.Shared.Results.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAsync();
            return View(authors.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AuthorAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _authorService.AddAsync(dto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return RedirectToAction("Index", "Author");
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
            var result = await _authorService.DeleteAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return RedirectToAction("Index", "Author");
            }
            else
            {
                // refactoring
                return RedirectToAction("Index", "Author");
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var author = await _authorService.GetAsync(id);
            return View(new AuthorUpdateDto()
            {
                Id = author.Data.Author.Id,
                Name = author.Data.Author.Name,
                Surname = author.Data.Author.Surname
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(AuthorUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _authorService.UpdateAsync(dto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }

            return View(dto);
        }
    }
}
