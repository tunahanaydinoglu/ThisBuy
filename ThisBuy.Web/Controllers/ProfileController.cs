﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
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
    public class ProfileController : Controller
    {
        ThisBuyContext db = new ThisBuyContext();
        // GET: Profile

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageProfile(int? id)
        {
            UserProfileViewModel users = new UserProfileViewModel()
            {
                User = db.Users.Find(id),
            };
            if (Session["userId"] == null)
            {
                return RedirectToAction("Yetki", "Admin/AdminHome");
            }
            else if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var sess = Session["userId"];
                var ses = Int32.Parse(sess.ToString());
                if (users == null)
                {
                    return HttpNotFound();
                }
                else if (ses != id)
                {
                    users.User = db.Users.Find(ses);
                    return View(users);
                }
                else
                {

                    return View(users);
                }
            }
        }

        [HttpPost]
        public ActionResult ManageProfile(UserProfileViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = db.Users.Find(model.User.Id);
            user.Name = model.User.Name;
            user.Surname = model.User.Surname;
            user.Password = model.User.Password;
            user.Twitter = model.User.Twitter;
            user.Photo = model.User.Photo;
            user.Address = model.User.Address;
            user.Email = model.User.Email;
            user.About = model.User.About;
            user.Instagram = model.User.Instagram;
            db.Users.AddOrUpdate(user);
            db.SaveChanges();
            RouteValueDictionary RouteInfo = new RouteValueDictionary();
            RouteInfo.Add("id", user.Id);
            return RedirectToAction("UserProfile", RouteInfo);
        }

        public ActionResult UserProfile(int? id)
        {
            UserProfileViewModel users = new UserProfileViewModel()
            {
                User = db.Users.Find(id),
            };
            if (id != null)
            {
                if (users != null)
                {

                    if (users.User.Photo != null)
                    {
                        return View(users);
                    }
                    else
                    {
                        users.User.Photo = "https://bootdey.com/img/Content/user_1.jpg";
                        return View(users);
                    }
                }
                else
                {
                    return HttpNotFound();

                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult OtherUser(int? id)
        {
            UserProfileViewModel users = new UserProfileViewModel()
            {
                User = db.Users.Find(id),
            };
            if (id != null)
            {
                if (users != null)
                {
                    if (users.User.Photo != null)
                    {
                        return View(users);
                    }
                    else
                    {
                        users.User.Photo = "https://bootdey.com/img/Content/user_1.jpg";
                        return View(users);
                    }
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}