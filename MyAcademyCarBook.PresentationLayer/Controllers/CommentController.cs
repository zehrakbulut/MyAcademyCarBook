using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ICarService _carService;


        public CommentController(ICommentService commentService, ICarService carService)
        {
            _commentService = commentService;
            _carService = carService;
        }

        public IActionResult Index()
        {
            var values=_commentService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddComment(int id)
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            _commentService.TInsert(comment);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteComment(int id)
        {
            var value=_commentService.TGetByID(id);
            _commentService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateComment(int id)
        {
            List<SelectListItem> values = (from x in _carService.TGetAllCarsWithBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = _commentService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentService.TUpdate(comment);
            return RedirectToAction("Index");
        }
    }
}
