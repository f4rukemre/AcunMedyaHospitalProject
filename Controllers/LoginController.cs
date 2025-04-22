using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AcunMedyaHospitalProject.Controllers
{
    public class LoginController : Controller
    {
        private AppDbContext db = new AppDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var kullanici = db.Admins.FirstOrDefault(a => a.Username == admin.Username && a.Password == admin.Password);
            if (kullanici != null)
            {
                // Başarılı giriş
                return RedirectToAction("Index","Doctor");
            }
            else
            {
                // Başarısız giriş
                ViewBag.Mesaj = "Geçersiz kullanıcı adı veya şifre";
                return View();
            }
        }
    }
}


    