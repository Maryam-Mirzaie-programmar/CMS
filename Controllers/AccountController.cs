using MyCms.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCms.Models;
using System.Web.Security;

namespace MyCms.Controllers
{
    public class AccountController : Controller
    {
        CmsContext db = new CmsContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login , string ReturnUrl="/")
        {
            if (ModelState.IsValid)
            {
                var admin = db.AdminLogins.Where(a => a.Username == login.Username && a.Password == login.Password).SingleOrDefault();
                if(admin == null)
                {
                    ModelState.AddModelError("Username", "نام کاربری یا کلمه عبور اشتباه است.");
                    return View(login);
                }
                FormsAuthentication.SetAuthCookie(login.Username, login.RememberMe);
                return Redirect(ReturnUrl);
            }
            return View(login);
        }


        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}