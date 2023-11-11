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
    public class RAMOzellikController : Controller
    {
        // GET: RAMOzellik
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var ram = c.RAMOzelliks.ToList().ToPagedList(sayfa, 6);
            return View(ram);
        }
        [HttpGet]
        public ActionResult RAMOzellikEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult RAMOzellikEkle(RAMOzellik r)
        {
            c.RAMOzelliks.Add(r);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RAMOzellikSil(int id)
        {
            var ram = c.RAMOzelliks.Find(id);
            c.RAMOzelliks.Remove(ram);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RAMOzellikGetir(int id)
        {
            var ram = c.RAMOzelliks.Find(id);
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View("RAMOzellikGetir", ram);
        }
        public ActionResult RAMOzellikGuncelle(RAMOzellik r)
        {
            var ram = c.RAMOzelliks.Find(r.ID);
            ram.Urunid = r.Urunid;
            ram.Fiyat = r.Fiyat;
            ram.BellekHizi = r.BellekHizi;
            ram.BellekKapasitesi = r.BellekKapasitesi;
            ram.BellekTeknoloji = r.BellekTeknoloji;
            ram.TepkimeSuresi = r.TepkimeSuresi;
            ram.BellekSayisi = r.BellekSayisi;
            ram.Sogutucu = r.Sogutucu;
            ram.UrunAilesi = r.UrunAilesi;
            ram.UrunSerisi = r.UrunSerisi;
            ram.Platform = r.Platform;
            ram.CikisYili = r.CikisYili;
            ram.TeknikPuan = r.TeknikPuan;
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}