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
    public class MonitorOzellikController : Controller
    {
        // GET: MonitorOzellik
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.MonitorOzelliks.ToList().ToPagedList(sayfa, 6);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult MonitorOzellikEkle()
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
        public ActionResult MonitorOzellikEkle(MonitorOzellik m)
        {
            c.MonitorOzelliks.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MonitorOzellikSil(int id)
        {
            var mos = c.MonitorOzelliks.Find(id);
            c.MonitorOzelliks.Remove(mos);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MonitorOzellikGetir(int id)
        {
            var mog = c.MonitorOzelliks.Find(id);
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View("MonitorOzellikGetir", mog);
        }
        public ActionResult MonitorOzellikGuncelle(MonitorOzellik m)
        {
            var mog = c.MonitorOzelliks.Find(m.ID);
            mog.Urunid = m.Urunid;
            mog.Fiyat = m.Fiyat;
            mog.EkranBoyutu = m.EkranBoyutu;
            mog.YenilemeHizi = m.YenilemeHizi;
            mog.EkranCozunurlugu = m.EkranCozunurlugu;
            mog.EkranTeknolojisi = m.EkranTeknolojisi;
            mog.TepkiSuresi = m.TepkiSuresi;
            mog.HDMI = m.HDMI;
            mog.DisplayPort = m.DisplayPort;
            mog.Hoperlor = m.Hoperlor;
            mog.CikisYili = m.CikisYili;
            mog.TeknikPuan = m.TeknikPuan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}