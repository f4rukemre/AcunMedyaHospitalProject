using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    
    public class ServiceController : Controller
    {
        private readonly AppDbContext db=new AppDbContext();
        public ActionResult Index()
        {
            var services=db.Services.ToList();
            return View(services);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }
        public ActionResult DeleteService(int id)
        {
            var service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var service=db.Services.Find(id);
            return View(service);
        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var updatedService=db.Services.Find(service.ID);
            updatedService.Name = service.Name;
            updatedService.Description = service.Description;
            updatedService.IconName = service.IconName;
            updatedService.ButtonName = service.ButtonName;
            updatedService.ButtonLink = service.ButtonLink;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}