using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminChartController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult ChartList()
        {
            var values = context.Charts.ToList();
            return View(values);
        }
    }
}