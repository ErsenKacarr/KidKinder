using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminAdminController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult AdminList()
        {
            var values = context.Admins.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdmin(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var value = context.Admins.Find(id);
            context.Admins.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = context.Admins.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            var value = context.Admins.Find(admin.AdminId);
            value.Username = admin.Username;
            value.Password = admin.Password;
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }
    }
}