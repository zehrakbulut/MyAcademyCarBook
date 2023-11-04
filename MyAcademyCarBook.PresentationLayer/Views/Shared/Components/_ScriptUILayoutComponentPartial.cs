using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCarBook.PresentationLayer.Views.Shared.Components
{
    public class _ScriptUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
