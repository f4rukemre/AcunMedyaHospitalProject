using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    
    public class ContactController : Controller
    {
        private readonly AppDbContext db=new AppDbContext();
        public ActionResult Index()
        {
            var contact=db.Contacts.ToList();
            return View(contact);
        }
        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index","Contact");
            }
            return View(contact);
        }
        public ActionResult DeleteContact(int id)
        {
            var contact= db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contact=db.Contacts.Find(id);
            return View(contact);
        }
        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {
            var updatedContact=db.Contacts.Find(contact.Id);
            updatedContact.Adress = contact.Adress;
            updatedContact.Phone = contact.Phone;
            updatedContact.Email = contact.Email;
            updatedContact.Longitude = contact.Longitude;
            updatedContact.Latitude = contact.Latitude;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}