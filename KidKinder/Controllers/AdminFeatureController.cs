using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminFeatureController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult FeatureList()
        {
            var values = context.Features.ToList();
            return View(values);
        }
        public ActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFeature(Feature feature)
        {
            context.Features.Add(feature);
            context.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = context.Features.Find(id);
            context.Features.Remove(value);
            context.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = context.Features.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFeature(Feature feature)
        {
            var value = context.Features.Find(feature.FeatureId);
            value.ImageUrl = feature.ImageUrl;
            value.Title = feature.Title;
            value.Description = feature.Description;
            value.Header = feature.Header;
            context.SaveChanges();
            return RedirectToAction("FeatureList");
        }

    }
}