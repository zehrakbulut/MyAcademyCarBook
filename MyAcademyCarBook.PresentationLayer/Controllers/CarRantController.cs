using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CarRantController : Controller
    {
        private readonly ICarRantService _carRantService;
        private readonly ICarService _carService;


        public CarRantController(ICarRantService carRantService, ICarService carService)
        {
            _carRantService = carRantService;
            _carService = carService;
        }

        public IActionResult Index()
        {
            var values=_carRantService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCarRant(int id)
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddCarRant(CarRant carRant)
        {
            _carRantService.TInsert(carRant);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCarRant(int id)
        {
            var value=_carRantService.TGetByID(id);
            _carRantService.TDelete(value); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCarRant(int id)
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = _carRantService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCarRant(CarRant carRant)
        {
            _carRantService.TUpdate(carRant);
            return RedirectToAction("Index");   
        }
    }
}
