using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminClassController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult ClassList()
        {
            var values = context.ClassRooms.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateClassRoom()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult CreateClassRoom(ClassRoom classroom)
        {
            context.ClassRooms.Add(classroom);
            context.SaveChanges();
            return RedirectToAction("ClassList");
        }

        public ActionResult DeleteClassRoom(int id)
        {
            var value = context.ClassRooms.Find(id);
            context.ClassRooms.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ClassList");
        }

        [HttpGet]
        public ActionResult UpdateClassRoom(int id)
        {
            var value = context.ClassRooms.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateClassRoom(ClassRoom classroom)
        {
            var value = context.ClassRooms.Find(classroom.ClassRoomId);
            value.ImageUrl = classroom.ImageUrl;
            value.Title = classroom.Title;
            value.Description = classroom.Description;
            context.SaveChanges();
            return RedirectToAction("ClassList");
        }

    }
}