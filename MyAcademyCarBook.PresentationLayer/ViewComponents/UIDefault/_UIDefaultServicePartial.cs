using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.UIDefault
{
    public class _UIDefaultServicePartial:ViewComponent
    {
        private readonly IServiceService _serviceService;

        public _UIDefaultServicePartial(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IViewComponentResult Invoke()
        {
            var values=_serviceService.TGetListAll();
            return View(values);
        }
    }
}
