using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class HowItWorkStepController : Controller
    {
        private readonly IHowItWorksStepService _howItWorkStepService;

        public HowItWorkStepController(IHowItWorksStepService howItWorkStepService)
        {
            _howItWorkStepService = howItWorkStepService;
        }

        public IActionResult Index()
        {
            var values=_howItWorkStepService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddHowItWorkStep()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHowItWorkStep(HowItWorksStep howItWorkStep)
        {
            _howItWorkStepService.TInsert(howItWorkStep);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHowItWorkStep(int id)
        {
            var value = _howItWorkStepService.TGetByID(id);
            _howItWorkStepService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateHowItWorkStep(int id)
        {
            var value = _howItWorkStepService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateHowItWorkStep(HowItWorksStep howItWorksStep)
        {
            _howItWorkStepService.TUpdate(howItWorksStep);
            return RedirectToAction("Index");
        }
    }
}
