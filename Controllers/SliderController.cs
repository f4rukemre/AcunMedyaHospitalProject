using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    
    public class SliderController : Controller
    {
        private readonly AppDbContext db=new AppDbContext();
        public ActionResult Index()
        {
            var sliders=db.Sliders.ToList();
            return View(sliders);
        }
        [HttpGet]
        public ActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSlider(Slider slider)
        {
            if (ModelState.IsValid)
            {
                db.Sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index", "Slider");
            }
            return View(slider);
        }
        public ActionResult DeleteSlider(int id)
        {
            var slider=db.Sliders.Find(id);
            db.Sliders.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var slider = db.Sliders.Find(id);
            return View(slider);
        }
        [HttpPost]
        public ActionResult UpdateSlider(Slider slider)
        {
            var updatedSlider = db.Sliders.Find(slider.Id);
            updatedSlider.Title = slider.Title;
            updatedSlider.Description = slider.Description;
            updatedSlider.ImageUrl = slider.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}