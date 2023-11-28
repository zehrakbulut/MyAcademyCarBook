using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class UIDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
