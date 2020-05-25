using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ThisBuy.Dal.Context;
using ThisBuy.Dal.Entities;
using ThisBuy.Web.Models;

namespace ThisBuy.Web.Controllers
{
    public class ProductController : Controller
    {
        ThisBuyContext db = new ThisBuyContext();
        // GET: Product
        public ActionResult Index(int? id)
        {
            if(id == null)
            {
                ProductIndexViewModel model = new ProductIndexViewModel
                {
                    Products = db.Products.ToList(),
                    Categories = db.Categories.ToList()
                };
                return View(model);
            }
            ProductIndexViewModel modell = new ProductIndexViewModel
            {
                Products = db.Products.ToList().Where(p=>p.CategoryId == id),
                Categories = db.Categories.ToList()
            };

            return View(modell);
        }

        //public ActionResult ProductListByCategory(int? id)
        //{
        //    ProductIndexViewModel model = new ProductIndexViewModel
        //    {
        //        Products = db.Products.ToList().Where(p=>p.CategoryId == id),
        //        Categories = db.Categories.ToList()
        //    };
        //    return View(model);
        //}

        public ActionResult ProductDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                ProductDetailViewModel model = new ProductDetailViewModel
                {
                    Product = db.Products.Find(id),
                    Comments = db.Comments.ToList().Where(c => c.ProductId == id),
                    Pays = db.Pays.ToList().Where(p => p.ProductId == id),
                    Photos = db.Photos.ToList().Where(p => p.ProductId == id)
                };
                    if (model.Product == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    Session["productId"] = model.Product.Id.ToString();
                    return View(model);
                }
            }
        }


        [HttpPost]
        public ActionResult AddComment(ProductDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Comment.UserId = Convert.ToInt32(Session["userId"]);
            model.Comment.ProductId = Convert.ToInt32(Session["productId"]);
            db.Comments.Add(model.Comment);
            db.SaveChanges();
            RouteValueDictionary RouteInfo = new RouteValueDictionary();
            RouteInfo.Add("id", Session["productId"]);
            return RedirectToAction("ProductDetail", RouteInfo);
        }

        [HttpPost]
        public ActionResult AddPay(ProductDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Pay.UserId = Convert.ToInt32(Session["userId"]);
            model.Pay.ProductId = Convert.ToInt32(Session["productId"]);
            db.Pays.Add(model.Pay);
            db.SaveChanges();
            RouteValueDictionary RouteInfo = new RouteValueDictionary();
            RouteInfo.Add("id", Session["productId"]);
            return RedirectToAction("ProductDetail", RouteInfo);
        }

    }
}