using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.UIDefault
{
    public class _UIDefaultHowItWorksStepPartial:ViewComponent
    {
        private readonly IHowItWorksStepService _howItWorksStepService;

        public _UIDefaultHowItWorksStepPartial(IHowItWorksStepService howItWorksStepService)
        {
            _howItWorksStepService = howItWorksStepService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _howItWorksStepService.TGetListAll();
            return View(values);
        }
    }
}
