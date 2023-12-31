using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.UIDefault
{
    public class _UIDefaultOfferPartial:ViewComponent
    {
        private readonly ICarService _carService;

        public _UIDefaultOfferPartial(ICarService carService)
        {
            _carService = carService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _carService.TGetAllCarsWithBrands();
            return View(values);
        }
    }
}
