using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminBookASeatController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult BookASeatList()
        {
            var values = context.BookASeats.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateBookASeat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBookASeat(BookASeat bookASeat)
        {
            context.BookASeats.Add(bookASeat);
            context.SaveChanges();
            return RedirectToAction("BookASeatList");
        }
        public ActionResult DeleteBookASeat(int id)
        {
            var value = context.BookASeats.Find(id);
            context.BookASeats.Remove(value);
            context.SaveChanges();
            return RedirectToAction("BookASeatList");
        }
        [HttpGet]
        public ActionResult UpdateBookASeat(int id)
        {
            var value = context.BookASeats.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBookASeat(BookASeat bookASeat)
        {
            var value = context.BookASeats.Find(bookASeat.BookASeatId);
            value.Name = bookASeat.Name;
            value.Email = bookASeat.Email;
            context.SaveChanges();
            return RedirectToAction("BookASeatList");
        }
    }
}