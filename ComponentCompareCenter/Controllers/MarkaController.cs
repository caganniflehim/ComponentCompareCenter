using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComponentCompareCenter.Models.Siniflar;
using PagedList;
using PagedList.Mvc;


namespace ComponentCompareCenter.Controllers
{
    public class MarkaController : Controller
    {
        // GET: Marka
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var markalar = c.Markas.ToList().ToPagedList(sayfa, 6);
            return View(markalar);
        }
        [HttpGet]
        public ActionResult MarkaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MarkaEkle(Marka m)
        {
            c.Markas.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MarkaSil(int id)
        {
            var mrk = c.Markas.Find(id);
            c.Markas.Remove(mrk);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MarkaGetir(int id)
        {
            var marka = c.Markas.Find(id);
            return View("MarkaGetir", marka);
        }
        public ActionResult MarkaGuncelle(Marka m)
        {
            var mrk = c.Markas.Find(m.MarkaID);
            mrk.MarkaAd = m.MarkaAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}