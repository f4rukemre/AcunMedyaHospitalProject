using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using AcunMedyaHospitalProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    
    public class DoctorController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            var doctors=db.Doctors.ToList();
            return View(doctors);
        }

        public ActionResult DoctorByDepartment(int id)
        {
            var doctors = db.Doctors.Where(x=>x.DepartmentId==id).ToList();
            return View("Index",doctors);
        }

        [HttpGet]
        public ActionResult CreateDoctor()
        {
            TempData["Departments"] = DepartmentHelper.GetDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult CreateDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index","Doctor");
            }
            TempData["Departments"] = DepartmentHelper.GetDepartments();
            return View(doctor);
        }
        public ActionResult DeleteDoctor(int id)
        {
            var doctor=db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateDoctor(int id)
        {
            var doctor= db.Doctors.Find(id);
            var department = db.Departments.ToList();
            var list = new SelectList(department, "ID", "Name", doctor.DepartmentId);
            ViewBag.Departments=list;
            return View(doctor);
        }
        [HttpPost]
        public ActionResult UpdateDoctor(Doctor doctor)
        {
            var updatedDoctor=db.Doctors.Find(doctor.ID);
            updatedDoctor.FirstName=doctor.FirstName;
            updatedDoctor.LastName=doctor.LastName;
            updatedDoctor.ImgUrl=doctor.ImgUrl;
            updatedDoctor.DepartmentId=doctor.DepartmentId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}