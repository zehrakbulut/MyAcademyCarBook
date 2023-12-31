using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CarDetailController : Controller
    {
        private readonly ICarDetailService _carDetailService;
        private readonly ICarService _carService;
        private readonly UserManager<AppUser> _userManager;


        public CarDetailController(ICarDetailService carDetailService, ICarService carService, UserManager<AppUser> userManager)
        {
            _carDetailService = carDetailService;
            _carService = carService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values=_carDetailService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCarDetail()
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            List<SelectListItem> values1 = (from x in _userManager.Users
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.v1 = values1;
            return View();
        }

        [HttpPost]
        public IActionResult AddCarDetail(CarDetail carDetail)
        {
            
            _carDetailService.TInsert(carDetail);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCarDetail(int id)
        {
            var value=_carDetailService.TGetByID(id);
            _carDetailService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCarDetail(int id)
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            List<SelectListItem> values1 = (from x in _userManager.Users
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.v1 = values1;
            var value = _carDetailService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCarDetail(CarDetail carDetail)
        {
            _carDetailService.TUpdate(carDetail);
            return RedirectToAction("Index");
        }
    }
}
