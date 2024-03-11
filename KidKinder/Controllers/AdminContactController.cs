using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult ContactList()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }
        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateContact(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }

        public ActionResult DeleteContact(int id)
        {
            var value = context.Contacts.Find(id);
            context.Contacts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = context.Contacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {
            var value = context.Contacts.Find(contact.ContactId);
            value.NameSurname = contact.NameSurname;
            value.Email = contact.Email;
            value.Subject = contact.Subject;
            value.Message = contact.Message;
            value.SendDate = contact.SendDate;
            value.IsRead = contact.IsRead;
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}