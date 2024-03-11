using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace KidKinder.Controllers
{
    public class AdminGalleryController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult GalleryList()
        {
            var value = context.Galleries.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateGallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGallery(Gallery gallery)
        {
            context.Galleries.Add(gallery);
            context.SaveChanges();
            return RedirectToAction("GalleryList");
        }
        public ActionResult DeleteGallery(int id)
        {
            var value = context.Galleries.Find(id);
            context.Galleries.Remove(value);
            context.SaveChanges();
            return RedirectToAction("GalleryList");
        }

        [HttpGet]
        public ActionResult UpdateGallery(int id)
        {
            var value = context.Galleries.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateGallery(Gallery gallery)
        {
            var value = context.Galleries.Find(gallery.GalleryId);
            value.ImageUrl = gallery.ImageUrl;
            value.IsTrue = gallery.IsTrue;
            return RedirectToAction("GalleryList");
        }

        [HttpGet]
        public ActionResult Passive(int id)
        {
            var value = context.Galleries.Find(id);
            value.IsTrue = false;
            context.SaveChanges();
            return RedirectToAction("GalleryList");
        }
        [HttpGet]
        public ActionResult Active(int id)
        {
            var value = context.Galleries.Find(id);
            value.IsTrue = true;
            context.SaveChanges();
            return RedirectToAction("GalleryList");
        }

    }
}