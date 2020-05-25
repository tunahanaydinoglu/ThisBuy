using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ThisBuy.Dal.Context;
using ThisBuy.Web.Models;

namespace ThisBuy.Web.Controllers
{
    public class SecurityController : Controller
    {
        ThisBuyContext db = new ThisBuyContext();

        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var user = db.Users.FirstOrDefault(x => x.Email == model.User.Email && x.Password == model.User.Password);
            if (user != null)
            {
                if(user.IsActive == true)
                {
                    Session["userId"] = user.Id.ToString();
                    return RedirectToAction("Index", "home");
                }
                else
                {
                    ViewBag.Mesaj = "Hesabınız engellendi itiraz için iletişim bölümünden bizlere ulaşabilirsiniz...";
                    return View();
                }
            }
            else
            {
                ViewBag.Mesaj = "Hatalı bir giriş yaptınız..";
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session.Remove("userId");
            return RedirectToAction("Login","Security");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.User.IsActive = true;
            model.User.RoleId = 2;
            db.Users.Add(model.User);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}