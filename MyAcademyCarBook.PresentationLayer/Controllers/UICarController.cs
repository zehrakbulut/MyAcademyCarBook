using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class UICarController : Controller
    {

        private readonly ICarService _carService;

        public UICarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            var values=_carService.TGetAllCarsWithBrands();
            return View(values);
        }
    }
}
