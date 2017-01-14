using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NorthwindProject.Business.Abstract;
using NorthwindProject.Entities.Concrete;
using NorthwindProject.MvcWebUI.Models;

namespace NorthwindProject.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user,bool rememberMe=false)
        {
            User userToCheck = _userService.GetByUserNameAndPassword(user);
            if (userToCheck==null)
            {
                TempData.Add("Message","This is not a valid username and password");
                return View();
            }
            FormsAuthentication.SetAuthCookie(user.UserName,rememberMe);
            return RedirectToAction("Index","Product");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Product");
        }
    }
}