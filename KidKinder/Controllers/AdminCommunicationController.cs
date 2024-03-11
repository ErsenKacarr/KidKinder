using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminCommunicationController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult CommunicationList()
        {
            var values = context.Communications.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateCommunication()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCommunication(Communication communication)
        {
            context.Communications.Add(communication);
            context.SaveChanges();
            return RedirectToAction("CommunicationListt");
        }
        public ActionResult DeleteCommunication(int id)
        {
            var value = context.Communications.Find(id);
            context.Communications.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CommunicationList");
        }

        [HttpGet]
        public ActionResult UpdateCommunication(int id)
        {
            var value = context.Communications.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCommunication(Communication communication)
        {
            var value = context.Communications.Find(communication.CommunicationId);
            value.Description = communication.Description;
            value.Address = communication.Address;
            value.Email = communication.Email;
            value.Phone = communication.Phone;
            context.SaveChanges();
            return RedirectToAction("CommunicationList");
        }
    }
}