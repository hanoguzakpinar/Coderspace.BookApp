using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Mvc.Areas.Member.Controllers
{
    [Area("Member")]
    public class HomeController : Controller
    {
        [Authorize(Roles = "Member")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
