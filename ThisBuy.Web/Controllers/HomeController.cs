using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThisBuy.Dal.Context;
using ThisBuy.Dal.Entities;
using ThisBuy.Web.Models;

namespace ThisBuy.Web.Controllers
{
    public class HomeController : Controller
    {
        ThisBuyContext db = new ThisBuyContext();

        public ActionResult Index()
        {
            using (var db=new ThisBuyContext())
            {
                var result = db.Roles.ToList();
            }
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.Contacts.Add(model.Contact);
            db.SaveChanges();
            ViewBag.Ekk = "Geri dönüşleriniz için teşekkürler. Mesajınız yetkililere iletilmiştir...";
            return View();
        }

        public ActionResult About()
        {

            return View();
        }
    }
}