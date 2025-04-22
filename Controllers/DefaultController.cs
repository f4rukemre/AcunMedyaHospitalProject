using AcunMedyaHospitalProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialSlider()
        {
            var sliders = db.Sliders.ToList();
            return PartialView(sliders);
        }
        public ActionResult PartialService()
        {
            var services = db.Services.ToList();
            return PartialView(services);
        }
        public ActionResult PartialDepartment()
        {
            var departments = db.Departments.ToList();
            return PartialView(departments);
        }
        public ActionResult PartialPatientComment()
        {
            var patientcomment = db.PatientComments.ToList();
            return PartialView(patientcomment);
        }
        public ActionResult PartialDoctor()
        {
            var doctor=db.Doctors.ToList();
            return PartialView(doctor);
        }
        public ActionResult PartialEmergency()
        {
            var contact=db.Contacts.FirstOrDefault();
            if (contact != null)
            {
                contact = new Entities.Contact();
            }
            return PartialView(contact);
        }
    }
}