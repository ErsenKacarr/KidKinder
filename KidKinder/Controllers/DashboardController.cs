using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Context;
using KidKinder.Entities;

namespace KidKinder.Controllers
{
    public class DashboardController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {   
            ViewBag.ResimCizmeCount=context.Teachers.Where(x => x.BranchId == context.Branches.Where (z=>z.Name =="Resim Çizim").Select(y => y.BranchId).FirstOrDefault()).Count();

            ViewBag.AvgPrice = context.ClassRooms.Average(x => x.Price).ToString("0.00");

            ViewBag.Matematik =context.Teachers.Where(x=> x.BranchId == context.Branches.Where (z=> z.Name =="Matematik").Select(y => y.BranchId).FirstOrDefault()).Count();

            ViewBag.BasitYazılımDilleriCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Basit Yazılım Dilleri").Select(y => y.BranchId).FirstOrDefault()).Count();

            ViewBag.FransızcaCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Fransızca").Select(y => y.BranchId).FirstOrDefault()).Count();

            ViewBag.Price = context.ClassRooms.Sum(x => x.Price).ToString("0.00");

            ViewBag.DilSınıfıCount= context.ClassRooms.Where(x=>x.ClassRoomId == context.ClassRooms.Where(z => z.Title == "Dil Sınıfı").Select(y=>y.ClassRoomId).FirstOrDefault()).Count();

            ViewBag.ÇizimSınıfıCount = context.ClassRooms.Where(x => x.ClassRoomId == context.ClassRooms.Where(z => z.Title == "Çizim Sınıfı").Select(y => y.ClassRoomId).FirstOrDefault()).Count();

            ViewBag.TemelBilimlerSınıfıCount = context.ClassRooms.Where(x => x.ClassRoomId == context.ClassRooms.Where(z => z.Title == "Temel Bilimler Sınıfı").Select(y => y.ClassRoomId).FirstOrDefault()).Count();

            ViewBag.TeacherCount = context.Teachers.Count();
            ViewBag.ServiceCount =context.Services.Count();
            ViewBag.TestimonialCount = context.Testimonials.Count();
            ViewBag.NotificationCount = context.Notifications.Count();
            ViewBag.GalleryCount = context.Galleries.Count();
            ViewBag.BranchCount = context.Branches.Count();
            ViewBag.AdminCount = context.Admins.Count();
            return View();
        }

      
    }
}