using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.UIAbout
{
    public class _UIAboutTeamComponentPartial:ViewComponent
    {
        private readonly ITeamService _teamService;

        public _UIAboutTeamComponentPartial(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _teamService.TGetListAll();
            return View(values);
        }
    }
}
