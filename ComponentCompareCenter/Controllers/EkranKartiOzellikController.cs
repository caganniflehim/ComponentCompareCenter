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
    public class EkranKartiOzellikController : Controller
    {
        // GET: EkranKartiOzellik
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.EkranKartiOzelliks.ToList().ToPagedList(sayfa, 6);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult EkranKartiOzellikEkle()
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
        public ActionResult EkranKartiOzellikEkle(EkranKartiOzellik e)
        {
            c.EkranKartiOzelliks.Add(e);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EkranKartiOzellikSil(int id)
        {
            var ekos = c.EkranKartiOzelliks.Find(id);
            c.EkranKartiOzelliks.Remove(ekos);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EkranKartiOzellikGetir(int id)
        {
            var ekos = c.EkranKartiOzelliks.Find(id);
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View("EkranKartiOzellikGetir", ekos);
        }
        public ActionResult EkranKartiOzellikGuncelle(EkranKartiOzellik e)
        {
            var ekos = c.EkranKartiOzelliks.Find(e.ID);
            ekos.Urunid = e.Urunid;
            ekos.Fiyat = e.Fiyat;
            ekos.İslemciÜretici = e.İslemciÜretici;
            ekos.BellekBoyutu = e.BellekBoyutu;
            ekos.BellekTürü = e.BellekTürü;
            ekos.GPUÇekirdek = e.GPUÇekirdek;
            ekos.GrafikKartıGücü = e.GrafikKartıGücü;
            ekos.VRDestegi = e.VRDestegi;
            ekos.ÇokluGPU = e.ÇokluGPU;
            ekos.BaglantiArayuz = e.BaglantiArayuz;
            ekos.DisplayPort = e.DisplayPort;
            ekos.HDMI = e.HDMI;
            ekos.SogutmaTipi = e.SogutmaTipi;
            ekos.FanSayısı = e.FanSayısı;
            ekos.Grafikİslemci = e.Grafikİslemci;
            ekos.İslemciÜretici = e.İslemciÜretici;
            ekos.GPUMimarisi = e.GPUMimarisi;
            ekos.Directx = e.Directx;
            ekos.CikisYili = e.CikisYili;
            ekos.TeknikPuan = e.TeknikPuan;
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}