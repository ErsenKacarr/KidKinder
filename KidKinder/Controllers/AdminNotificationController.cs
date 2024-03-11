using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminNotificationController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult NotificationList()
        {       
            var values = context.Notifications.ToList();
            return View(values);
        }
        public ActionResult CreateNotification()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNotification(Notification notification)
        {
            context.Notifications.Add(notification);
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        public ActionResult DeleteNotification(int id)
        {
            var value = context.Notifications.Find(id);
            context.Notifications.Remove(value);
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        [HttpGet]
        public ActionResult UpdateNotification(int id)
        {
            var value = context.Notifications.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateNotification(Notification notification)
        {
            var value = context.Notifications.Find(notification.NotificationId);
            value.ImageUrl = notification.ImageUrl;
            value.Title = notification.Title;
            value.Description = notification.Description;
            value.NotificationDate = notification.NotificationDate;
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
    }
}