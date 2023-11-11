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
    public class PowerSuppleyOzellikController : Controller
    {
        // GET: PowerSuppleyOzellik
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var power = c.PowerSupplyOzelliks.ToList().ToPagedList(sayfa, 6);
            return View(power);
        }
        [HttpGet]
        public ActionResult PowerSupplyOzellikEkle()
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
        public ActionResult PowerSupplyOzellikEkle(PowerSuppleyOzellik p)
        {
            c.PowerSupplyOzelliks.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PowerSupplyOzellikSil(int id)
        {
            var pow = c.PowerSupplyOzelliks.Find(id);
            c.PowerSupplyOzelliks.Remove(pow);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PowerSupplyOzellikGetir(int id)
        {
            var pow = c.PowerSupplyOzelliks.Find(id);
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View("PowerSupplyOzellikGetir", pow);
        }
        public ActionResult PowerSupplyOzellikGuncelle(PowerSuppleyOzellik p)
        {
            var pow = c.PowerSupplyOzelliks.Find(p.ID);
            pow.Urunid = p.Urunid;
            pow.Fiyat = p.Fiyat;
            pow.Guc = p.Guc;
            pow.GucVerimliligi = p.GucVerimliligi;
            pow.KabloTipi = p.KabloTipi;
            pow.FanBoyutu = p.FanBoyutu;
            pow.PFC = p.PFC;
            pow.Anahtar = p.Anahtar;
            pow.Model = p.Model;
            pow.CikisYili = p.CikisYili;
            pow.TeknikPuan = p.TeknikPuan;
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}