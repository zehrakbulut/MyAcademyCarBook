using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.UIAbout
{
    public class _UIAboutHistoryComponentPartial:ViewComponent
    {
        private readonly ICompanyService _companyService;

        public _UIAboutHistoryComponentPartial(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IViewComponentResult Invoke()
        {
            var latestCompany = _companyService.TGetListAll().OrderByDescending(c => c.CompanyID).FirstOrDefault(); 
            return View(latestCompany);
        }
    }
}
