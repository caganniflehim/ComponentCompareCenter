using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComponentCompareCenter.Models.Siniflar;

namespace ComponentCompareCenter.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Uyes.ToList();
            return View(degerler);
        }
   
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(Uye u)
        {
            c.Uyes.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeSil(string id)
        {
            var uye = c.Uyes.Find(id);
            c.Uyes.Remove(uye);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(string id)
        {
            var uye= c.Uyes.Find(id);
         
            return View("UyeGetir",uye);
        }
        public ActionResult UyeGuncelle(Uye u)
        {
            var uyg = c.Uyes.Find(u.uyeID);
            uyg.uyeAd = u.uyeAd;
            uyg.uyeSoyad = u.uyeSoyad;
            uyg.uyeAdresi = u.uyeAdresi;
            uyg.uyeEposta = u.uyeEposta;
            uyg.uyeTelNo = u.uyeTelNo;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}