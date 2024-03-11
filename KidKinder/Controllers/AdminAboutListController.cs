using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminAboutListController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult AboutsList()
        {
            var values = context.AboutLists.ToList();
            return View(values);
        }
        public ActionResult CreateAboutList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAboutList(AboutList aboutlist)
        {
            context.AboutLists.Add(aboutlist);
            context.SaveChanges();
            return RedirectToAction("AboutsList");
        }
        public ActionResult DeleteAboutList(int id)
        {
            var value = context.AboutLists.Find(id);
            context.AboutLists.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutsList");
        }

        [HttpGet]
        public ActionResult UpdateAboutList(int id)
        {
            var value = context.AboutLists.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAboutList(AboutList aboutlist)
        {
            var value = context.AboutLists.Find(aboutlist.AboutListId);
            value.Description = aboutlist.Description;
            context.SaveChanges();
            return RedirectToAction("AboutsList");
        }
    }
}