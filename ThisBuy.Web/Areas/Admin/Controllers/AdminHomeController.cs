using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThisBuy.Web.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            if(Session["admin"] == "admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Yetki","AdminHome");
            }
        }
        public ActionResult Yetki()
        {
            return View();
        }
    }
}