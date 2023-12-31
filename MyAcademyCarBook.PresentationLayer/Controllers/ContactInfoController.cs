using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        public IActionResult Index()
        {
            var values = _contactInfoService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddContactInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContactInfo(ContactInfo contactInfo)
        {
            _contactInfoService.TInsert(contactInfo);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteContactInfo(int id)
        {
            var value = _contactInfoService.TGetByID(id);
            _contactInfoService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateContactInfo(int id)
        {
            var value = _contactInfoService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateContactInfo(ContactInfo contactInfo)
        {
            _contactInfoService.TUpdate(contactInfo);
            return RedirectToAction("Index");
        }
    }
}
