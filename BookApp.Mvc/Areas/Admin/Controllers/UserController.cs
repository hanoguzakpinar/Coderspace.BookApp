using BookApp.Entities;
using BookApp.Mvc.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookApp.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.GetUsersInRoleAsync("Member");
            return View(new UserListModel()
            {
                Users = users
            });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is not null)
            {
                await _userManager.DeleteAsync(user);
                return RedirectToAction("Index", User);
            }
            else
            {
                //refactor
                return NotFound();
            }
        }

        public async Task<IActionResult> Assign(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = await _userManager.GetRolesAsync(user);
            if (user is not null)
            {
                if (!roles.Contains("Admin"))
                {
                    await _userManager.AddToRoleAsync(user, "Admin");

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    //refactor
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                //refactor
                return NotFound();
            }
        }
    }
}
