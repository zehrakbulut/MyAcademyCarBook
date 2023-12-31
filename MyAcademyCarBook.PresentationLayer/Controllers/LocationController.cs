using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public IActionResult Index()
        {
            var values=_locationService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddLocation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLocation(Location location)
        {
            _locationService.TInsert(location);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteLocation(int id)
        {
            var value = _locationService.TGetByID(id);
            _locationService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateLocation(int id)
        {
            var value = _locationService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateLocation(Location location)
        {
            _locationService.TUpdate(location);
            return RedirectToAction("Index");
        }
    }
}
