using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.UIAbout
{
    public class _UIAboutCompanyComponentPartial:ViewComponent
    {
        private readonly ICompanyService _companyService;

        public _UIAboutCompanyComponentPartial(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _companyService.TGetListAll().Take(1).ToList();
            return View(values);
        }
    }
}
