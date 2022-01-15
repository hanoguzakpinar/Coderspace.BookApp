using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BookApp.Entities;
using BookApp.Entities.Dtos.AuthDtos;

namespace BookApp.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user is not null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var result =
                        await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe,
                            false);
                    if (result.Succeeded)
                    {
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { Area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { Area = "Member" });
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Eposta adresiniz veya şifreniz yanlış.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var user = _mapper.Map<User>(dto);
            user.UserName = dto.Email;

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Member");
                return RedirectToAction("Login", "Auth", new { Area = "" });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View(dto);
            }
        }

    }
}