using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values=_teamService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            _teamService.TInsert(team);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTeam(int id)
        {
            var value = _teamService.TGetByID(id);
            _teamService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            var value = _teamService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateTeam(Team team)
        {
            _teamService.TUpdate(team);
            return RedirectToAction("Index");
        }
    }
}
