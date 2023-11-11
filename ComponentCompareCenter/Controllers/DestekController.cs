using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComponentCompareCenter.Models.Siniflar;

namespace ComponentCompareCenter.Controllers
{
    public class DestekController : Controller
    {
        // GET: Destek
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var d = c.Desteks.ToList();
            return View(d);
        }

        [HttpGet]
        public ActionResult DestekEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DestekEkle(Destek d)//
        {
            c.Desteks.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DestekSil(int id)
        {
            var ds = c.Desteks.Find(id);
            c.Desteks.Remove(ds);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DestekGetir(int id)
        {
            var destek = c.Desteks.Find(id);
            return View("DestekGetir", destek);
        }
        public ActionResult DestekGuncelle(Destek d)
        {
            var dg = c.Desteks.Find(d.Id);
            dg.sorular = d.sorular;
            dg.cevaplar = d.cevaplar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}