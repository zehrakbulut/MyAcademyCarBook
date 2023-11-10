using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.CarDetailComponents
{
    public class _CarDetailAboutAuthorComponentResult:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
