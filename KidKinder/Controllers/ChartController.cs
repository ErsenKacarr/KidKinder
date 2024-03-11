using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using KidKinder.Context;




namespace KidKinder.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Grafik()
        {
            return Json(siniflar(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> siniflar()
        {
            List<Class1> cs = new List<Class1>();
            KidKinderContext context = new KidKinderContext();
            cs = context.ClassRooms.Select(x => new Class1
            {
               ClassName = x.Title,
               ClassCount = x.TotalSeat
            }).ToList();
            return cs;
        }
    }
}