using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThisBuy.Dal.Context;
using ThisBuy.Dal.Entities;

namespace ThisBuy.Web.Areas.Admin.Controllers
{
    public class AdminPaysController : Controller
    {
        private ThisBuyContext db = new ThisBuyContext();

        // GET: Admin/AdminPays
        public ActionResult Index()
        {
            var pays = db.Pays.Include(p => p.Product).Include(p => p.User);
            return View(pays.ToList());
        }

        // GET: Admin/AdminPays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay pay = db.Pays.Find(id);
            if (pay == null)
            {
                return HttpNotFound();
            }
            return View(pay);
        }

        // GET: Admin/AdminPays/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Admin/AdminPays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Offer,UserId,ProductId")] Pay pay)
        {
            if (ModelState.IsValid)
            {
                db.Pays.Add(pay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", pay.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", pay.UserId);
            return View(pay);
        }

        // GET: Admin/AdminPays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay pay = db.Pays.Find(id);
            if (pay == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", pay.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", pay.UserId);
            return View(pay);
        }

        // POST: Admin/AdminPays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Offer,UserId,ProductId")] Pay pay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", pay.ProductId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", pay.UserId);
            return View(pay);
        }

        // GET: Admin/AdminPays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay pay = db.Pays.Find(id);
            if (pay == null)
            {
                return HttpNotFound();
            }
            return View(pay);
        }

        // POST: Admin/AdminPays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pay pay = db.Pays.Find(id);
            db.Pays.Remove(pay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
