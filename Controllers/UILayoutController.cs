﻿using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using AcunMedyaHospitalProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    public class UILayoutController : Controller
    {
        private readonly AppDbContext db=new AppDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialAppointmentForm()
        {
            TempData["Departments"]=DepartmentHelper.GetDepartments();
            return PartialView();
        }
        public ActionResult PartialFooter()
        {
            var departments=db.Departments.ToList();
            var socialMedias=db.SocialMedia.ToList();

            var model = new SosyalBölüm
            {
                Departments = departments,
                SocialMedia = socialMedias
            };
            return PartialView(model);
        }
        public ActionResult PartialHeader()
        {
            return PartialView();
        }
        public ActionResult PartialScripts()
        {
            return PartialView();
        }
        public ActionResult PartialSiteHeader()
        {
            return PartialView();
        }
        [HttpGet]
        public JsonResult GetDoctorsByDepartmentId(int departmentId)
        {
            var doctors=db.Doctors.Where(x=>x.DepartmentId==departmentId)
                .Select(x => new {x.ID,x.FirstName,x.LastName})
                .ToList();
            return Json(doctors,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult MakeAppointment(Appointment appointment)
        {
            appointment.Status=Enums.AppointmentStatus.Pending;
            appointment.CreatedDate=DateTime.UtcNow;
            db.Appointments.Add(appointment);
            db.SaveChanges();
            return RedirectToAction("Index","Default");
        }
    }
}