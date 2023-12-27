using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.UICar
{
    public class _UICarFeatureComponentPartial:ViewComponent
    {
         public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
