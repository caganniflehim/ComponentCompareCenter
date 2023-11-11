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
    public class AnakartOzellikController : Controller
    {
        // GET: AnakartOzellik
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var anakart = c.AnakartOzelliks.ToList().ToPagedList(sayfa,6);
            return View(anakart);
        }
        [HttpGet]
        public ActionResult AnakartOzellikEkle()
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
        public ActionResult AnakartOzellikEkle(AnakartOzellik a)
        {
            c.AnakartOzelliks.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AnakartOzellikSil(int id)
        {
            var akr = c.AnakartOzelliks.Find(id);
            c.AnakartOzelliks.Remove(akr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AnakartOzellikGetir(int id)
        {
            var anakart = c.AnakartOzelliks.Find(id);
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View("AnakartOzellikGetir", anakart);
        }
        public ActionResult AnakartOzellikGuncelle(AnakartOzellik a)
        {
            var akr = c.AnakartOzelliks.Find(a.ID);
            akr.Urunid = a.Urunid;
            akr.Fiyat = a.Fiyat;
            akr.YongaSetiModeli = a.YongaSetiModeli;
            akr.FormFaktor = a.FormFaktor;
            akr.IslemciSoketi = a.IslemciSoketi;
            akr.BellekTeknolojisi = a.BellekTeknolojisi;
            akr.BellekSaatHizi = a.BellekSaatHizi;
            akr.BellekKanali = a.BellekKanali;
            akr.M2Yuvasi = a.M2Yuvasi;
            akr.HizAsirtma = a.HizAsirtma;
            akr.Bluetooth = a.Bluetooth;
            akr.Aydınlatma = a.Aydınlatma;
            akr.WiFi = a.WiFi;
            akr.CikisYili = a.CikisYili;
            akr.TeknikPuan = a.TeknikPuan;
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}