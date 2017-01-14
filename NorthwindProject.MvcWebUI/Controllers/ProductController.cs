using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using NorthwindProject.Business.Abstract;
using NorthwindProject.Business.Concrete.Managers;
using NorthwindProject.DataAccess.Concrete.EntityFramework;
using NorthwindProject.Entities.ComplexTypes;
using NorthwindProject.Entities.Concrete;
using NorthwindProject.MvcWebUI.Models;

namespace NorthwindProject.MvcWebUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public int PageSize = 10;
        [AllowAnonymous]
        public ActionResult Index(int? categoryId, int page = 1)
        {
            int productCount = _productService.GetProductsCountByCategory(categoryId);
            var products = _productService.GetAll(new ProductFilter
            {
                CategoryId = categoryId,
                Page = page,
                PageSize = PageSize
            });
            return View(new ProductListViewModel
            {
                Products =products
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    CurrentCategory = categoryId,
                    TotalPageCount = (int)Math.Ceiling((decimal)productCount/PageSize),
                    BaseUrl = String.Format("/Product/Index/?categoryId={0}&page=",categoryId)
                }
            });
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new ProductAddViewModel
            {
                Categories = _categoryService.GetAll().Select(item=>new SelectListItem()
                {Text = item.CategoryName, Value = item.Id.ToString()}).ToList()

            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product product)
        {
            _productService.Add(product);
            TempData.Add("Message","The product was successfully added");
            return RedirectToAction("Index");
        }

        [HttpGet]
        
        public ActionResult Update(int id)
        {
            return View(new ProductAddViewModel
            {
                Product = _productService.GetById(id),
                Categories = _categoryService.GetAll().Select(item => new SelectListItem() { Text = item.CategoryName, Value = item.Id.ToString() }).ToList()

            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Product product)
        {
            _productService.Update(product);
            TempData.Add("Message", "The product was successfully updated");
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _productService.Delete(new Product{Id = id});
            TempData.Add("Message", "The product was successfully deleted");
            return RedirectToAction("Index");
        }
    }
}