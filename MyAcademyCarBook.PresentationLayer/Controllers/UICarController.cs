﻿using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class UICarController : Controller
    {

        private readonly ICarService _carService;
        private readonly ICarRantService _carRantService;

        public UICarController(ICarService carService, ICarRantService carRantService)
        {
            _carService = carService;
            _carRantService = carRantService;
        }

        public IActionResult Index()
        {
            var values=_carService.TGetAllCarsWithBrands();
            return View(values);
        }

        [HttpGet]
        public IActionResult CarRant(int id)
        {
            ViewBag.Brand = _carService.TGetAllCarsWithBrands().Where(x=>x.CarID == id).Select(y=>y.Brand.BrandName).FirstOrDefault();
            ViewBag.ImageUrl = _carService.TGetAllCarsWithBrands().Where(x=>x.CarID == id).Select(y=>y.ImageUrl).FirstOrDefault();
            ViewBag.Model = _carService.TGetAllCarsWithBrands().Where(x=>x.CarID == id).Select(y=>y.Model).FirstOrDefault();
            ViewBag.GearType = _carService.TGetAllCarsWithBrands().Where(x=>x.CarID == id).Select(y=>y.GearType).FirstOrDefault();
            ViewBag.Year = _carService.TGetAllCarsWithBrands().Where(x=>x.CarID == id).Select(y=>y.Year).FirstOrDefault();
            ViewBag.CarCategory = _carService.TGetAllCarsWithBrands().Where(x=>x.CarID == id).Select(y=>y.CarCategory.CategoryName).FirstOrDefault();
            ViewBag.KM = _carService.TGetAllCarsWithBrands().Where(x=>x.CarID == id).Select(y=>y.Km).FirstOrDefault();
            ViewBag.PersonCount = _carService.TGetAllCarsWithBrands().Where(x=>x.CarID == id).Select(y=>y.PersonCount).FirstOrDefault();
            ViewBag.DailyPrice = _carService.TGetAllCarsWithBrands().Where(x=>x.CarID == id).Select(y=>y.DailyPrice).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public IActionResult CarRant(int id, string fullName, string Email, DateTime startDate, DateTime endDate)
        {
            int dayNumber = (int)(endDate - startDate).TotalDays;

            var car = _carService.TGetAllCarsWithBrands().FirstOrDefault(x => x.CarID == id);

            int carDayPrice = (int)car.DailyPrice;

            var values = new CarRant()
            {
                FullName = fullName,
                Email = Email,
                DayNumber = dayNumber,
                TotalPrice = dayNumber * carDayPrice,
                CarID = id,
            };

            TempData["SuccessMessage"] = "Kiralama işlemi başarıyla gerçekleştirildi.";

            _carRantService.TInsert(values);
            return RedirectToAction("Index", "UIDefault");
        }


    }
}
