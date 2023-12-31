using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values=_contactService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _contactService.TInsert(contact);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var value = _contactService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return RedirectToAction("Index");
        }
    }
}
