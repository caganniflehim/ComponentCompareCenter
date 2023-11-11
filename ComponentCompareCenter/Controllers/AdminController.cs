using ComponentCompareCenter.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComponentCompareCenter.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var h = c.Admins.ToList();
            return View(h);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(Admin a)
        {
            c.Admins.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            var akr = c.Admins.Find(id);
            c.Admins.Remove(akr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminGetir(int id)
        {
            var admin = c.Admins.Find(id);

            return View("AdminGetir", admin);
        }
        public ActionResult AdminGuncelle(Admin a)
        {
            var ad = c.Admins.Find(a.AdminID);
            ad.KullaniciAdi = a.KullaniciAdi;
            ad.KullaniciAdi = a.Sifre;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}