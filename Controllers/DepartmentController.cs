using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    
    public class DepartmentController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            var department = db.Departments.ToList();
            return View(department);
        }
        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index", "Department");
            }
            return View(department);
        }
        public ActionResult DeleteDepartment(int id)
        {
            var department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateDepartment(int id)
        {
            var department =db.Departments.Find(id);
            return View(department);
        }
        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            var updatedDepartment=db.Departments.Find(department.ID);
            updatedDepartment.Name = department.Name;
            updatedDepartment.Description = department.Description;
            updatedDepartment.ImgUrl=department.ImgUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}