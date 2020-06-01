using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThisBuy.Dal.Context;

namespace ThisBuy.Web.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        ThisBuyContext db = new ThisBuyContext();
        // GET: Admin/ContactsJS
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var contact = db.Contacts.Find(id);
            return View(contact);
        }
    }
}