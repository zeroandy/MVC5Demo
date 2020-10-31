using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC5Demo.Models.VIewModel;

namespace MVC5Demo.Controllers
{
    //[Authorize(Roles = "admin,manager", Users = "will,john")]
    [Authorize]
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginVM login)
        {
            if (ModelState.IsValid && ValidateUser(login))
            {
                FormsAuthentication.RedirectFromLoginPage(login.Username, false);

                TempData["LoginResult"] = "Login成功！";
                return Content("1");
            }
            else
            {
                TempData["LoginResult"] = "Login Fail,pls check！";
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        private bool ValidateUser(LoginVM login)
        {
            return login.Username == "andy";
        }
    }
}