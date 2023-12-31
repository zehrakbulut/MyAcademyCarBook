using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminLayoutController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.userImage = TempData["userName"].ToString();
            return View();
        }
    }
}
