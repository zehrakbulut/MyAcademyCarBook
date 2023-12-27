using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{

    public class UIServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public UIServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.TGetListAll();
            return View(values);
        }
    }
}
