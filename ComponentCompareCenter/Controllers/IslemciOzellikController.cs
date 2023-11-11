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
    public class IslemciOzellikController : Controller
    {
        // GET: IslemciOzellik
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var islemci = c.IslemciOzelliks.ToList().ToPagedList(sayfa, 6);
            return View(islemci);
        }
        [HttpGet]
        public ActionResult IslemciOzellikEkle()
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
        public ActionResult IslemciOzellikEkle(IslemciOzellik i)
        {
            c.IslemciOzelliks.Add(i);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IslemciOzellikSil(int id)
        {
            var ism = c.IslemciOzelliks.Find(id);
            c.IslemciOzelliks.Remove(ism);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IslemciOzellikGetir(int id)
        {
            var islemci = c.IslemciOzelliks.Find(id);
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View("IslemciOzellikGetir", islemci);
        }
        public ActionResult IslemciOzellikGuncelle(IslemciOzellik i)
        {
            var ism = c.IslemciOzelliks.Find(i.ID);
            ism.Urunid = i.Urunid;
            ism.Fiyat = i.Fiyat;
            ism.Cekirdek = i.Cekirdek;
            ism.SanalCekirdek = i.SanalCekirdek;
            ism.TemelFrekans = i.TemelFrekans;
            ism.BellekTuru = i.BellekTuru;
            ism.Soket = i.Soket;
            ism.DahiliGrafikIslemci = i.DahiliGrafikIslemci;
            ism.OnBellek = i.OnBellek;
            ism.IslenciSerisi = i.IslenciSerisi;
            ism.Jenerasyon = i.Jenerasyon;
            ism.IslemciMimarisi = i.IslemciMimarisi;
            ism.CikisYili = i.CikisYili;
            ism.TeknikPuan = i.TeknikPuan;
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}