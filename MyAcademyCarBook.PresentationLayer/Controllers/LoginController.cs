using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.EntityLayer.Concrete;
using MyAcademyCarBook.PresentationLayer.Models;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result=await _signInManager.PasswordSignInAsync(model.UserName, model.Password,false,false);
            if(result.Succeeded)
            {
                TempData["userName"] = _userManager.Users.Where(x=>x.Name == model.UserName).Select(y=>y.ImageUrl).FirstOrDefault();
                return RedirectToAction("Index","CarStatus");
            }
            return View();
        }
    }
}
