﻿using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.CarDetailComponents
{
    public class _CarDetailCategoryComponentPartial:ViewComponent
    {

        private readonly ICarCategoryService _carCategoryService;

        public _CarDetailCategoryComponentPartial(ICarCategoryService carCategoryService)
        {
            _carCategoryService = carCategoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _carCategoryService.TGetListAll();
            return View(values);
        }
    }
}
    