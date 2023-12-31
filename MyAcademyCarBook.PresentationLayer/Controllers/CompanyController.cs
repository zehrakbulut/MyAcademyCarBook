using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            var values=_companyService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCompany(Company company)
        {
            _companyService.TInsert(company);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCompany(int id)
        {
            var value = _companyService.TGetByID(id);
            _companyService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCompany(int id)
        {
            var value = _companyService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCompany(Company company)
        {
            _companyService.TUpdate(company);
            return RedirectToAction("Index");
        }
    }
}
