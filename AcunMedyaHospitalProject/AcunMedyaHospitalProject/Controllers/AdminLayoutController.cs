using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly AppDbContext db=new AppDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialHeader()
        {
            return PartialView();
        }
        public ActionResult PartialSidebar()
        {
            return PartialView();
        }
        public ActionResult PartialNavbar()
        {
            var messages=db.Messages.ToList();
            var appointments=db.Appointments.ToList();

            var model = new RandevuMesaj
            {
                Appointments = appointments,
                Messages = messages
            };
            return PartialView(model);
        }
        public ActionResult PartialFooter()
        {
            return PartialView();
        }
        public ActionResult PartialScripts()
        {
            return PartialView();
        }
    }
}