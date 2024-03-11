using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Entities;
using KidKinder.Context;
using System.Data.Entity;

namespace KidKinder.Controllers
{
    
    public class AboutController : Controller
    {
        // GET: About
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AboutHeaderPartial()
        {
            return PartialView();
        }

        public ActionResult AboutAboutPartial() 
        {
            //ViewBag.description = context.AboutLists.Select(x => x.Description).FirstOrDefault();
            return  PartialView();
        }
    }
}