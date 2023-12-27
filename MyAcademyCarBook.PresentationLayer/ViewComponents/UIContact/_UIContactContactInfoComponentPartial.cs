using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.UIContact
{
    public class _UIContactContactInfoComponentPartial:ViewComponent
    {
        private readonly IContactInfoService _contactInfoService;

        public _UIContactContactInfoComponentPartial(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactInfoService.TGetListAll();
            return View(values);
        }
    }
}
