using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthwindProject.Business.Abstract;
using NorthwindProject.MvcWebUI.Models;

namespace NorthwindProject.MvcWebUI.Controllers
{
    public class CategoryController : Controller
    {

        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public PartialViewResult List(int? categoryId)
        {
            return PartialView(new CategoryListViewModel
            {
                Categories = _categoryService.GetAll(),
                CurrentCategory = categoryId
            });
        }
    }
}