using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class UIAboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
