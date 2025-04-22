using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    public class MessageController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            var messages = db.Messages.ToList();
            return View(messages);
        }
        [HttpGet]
        public ActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index", "Message");
            }
            return View(message);
        }
        public ActionResult DeleteMessage(int id)
        {
            var message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var message=db.Messages.Find(id);
            return View(message);
        }
        [HttpPost]
        public ActionResult UpdateMessage(Message message)
        {
            var updatedMessage=db.Messages.Find(message.Id);
            updatedMessage.Content = message.Content;
            updatedMessage.Name = message.Name;
            updatedMessage.Email = message.Email;
            updatedMessage.Subject = message.Subject;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}