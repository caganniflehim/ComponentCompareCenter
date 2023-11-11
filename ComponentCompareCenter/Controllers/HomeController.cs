using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ComponentCompareCenter.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace ComponentCompareCenter.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SliderPartial()
        {

            return View(c.Sliders.ToList().OrderByDescending(x => x.SliderId)); // slider id ye göre son eklenen başta olucak
        }

        //kartlar
        public ActionResult AnakartCard()
        {
            return View(c.AnakartOzelliks.Take(6).ToList().OrderByDescending(x => x.ID));
        }

        public ActionResult MonitorCard()
        {
            return View(c.MonitorOzelliks.Take(6).ToList().OrderByDescending(x => x.ID));
        }

        public ActionResult EkranKartiCard()
        {
            return View(c.EkranKartiOzelliks.Take(6).ToList().OrderByDescending(x => x.ID));
        }

        public ActionResult İslemciCard()
        {
            return View(c.IslemciOzelliks.Take(6).ToList().OrderByDescending(x => x.ID));
        }

        public ActionResult RamCard()
        {
            return View(c.RAMOzelliks.Take(6).ToList().OrderByDescending(x => x.ID));
        }

        public ActionResult PowerSuppleyCard()
        {
            return View(c.PowerSupplyOzelliks.Take(6).ToList().OrderByDescending(x => x.ID));
        }
        //Listeleme
        public ActionResult AnakartListele(int sayfa = 1)
        {
            return View(c.AnakartOzelliks.OrderByDescending(x => x.TeknikPuan).ToList().ToPagedList(sayfa, 4));
        }

        public ActionResult MonitorListele(int sayfa = 1)
        {
            return View(c.MonitorOzelliks.OrderByDescending(x => x.TeknikPuan).ToList().ToPagedList(sayfa, 4));
        }

        public ActionResult EkranKartiListele(int sayfa = 1)
        {
            return View(c.EkranKartiOzelliks.OrderByDescending(x => x.TeknikPuan).ToList().ToPagedList(sayfa, 4));
        }

        public ActionResult İslemciListele(int sayfa = 1)
        {
            return View(c.IslemciOzelliks.OrderByDescending(x => x.TeknikPuan).ToList().ToPagedList(sayfa, 4));
        }

        public ActionResult RamListele(int sayfa = 1)
        {
            return View(c.RAMOzelliks.OrderByDescending(x => x.TeknikPuan).ToList().ToPagedList(sayfa, 4));
        }

        public ActionResult PowerSupplyListele(int sayfa = 1)
        {
            return View(c.PowerSupplyOzelliks.OrderByDescending(x => x.TeknikPuan).ToList().ToPagedList(sayfa, 4));
        }
        //listeleme son
        //detay sayfası

        public ActionResult AnakartDetay(int id)
        {
            return View(c.AnakartOzelliks.Where(x => x.ID == id).FirstOrDefault());

        }

        public ActionResult MonitorDetay(int id)
        {
            return View(c.MonitorOzelliks.Where(x => x.ID == id).FirstOrDefault());
        }
        public ActionResult EkranKartiDetay(int id)
        {
            return View(c.EkranKartiOzelliks.Where(x => x.ID == id).FirstOrDefault());
        }
        public ActionResult IslemciDetay(int id)
        {
            return View(c.IslemciOzelliks.Where(x => x.ID == id).FirstOrDefault());
        }
        public ActionResult RamDetay(int id)
        {
            return View(c.RAMOzelliks.Where(x => x.ID == id).FirstOrDefault());
        }
        public ActionResult PowerSupplyDetay(int id)
        {
            return View(c.PowerSupplyOzelliks.Where(x => x.ID == id).FirstOrDefault());
        }

        public ActionResult Hakkımızda()
        {
            return View(c.Hakkimizdas.FirstOrDefault());
        }
        public ActionResult Iletisim(string adsoyad = null, string email = null, string konu = null, string mesaj = null)
        {
            if (adsoyad != null && email != null)
            {


                WebMail.SmtpServer = "componentcomparecenter.com.tr";
                WebMail.EnableSsl = false;
                WebMail.UserName = "info@componentcomparecenter.com.tr";
                WebMail.Password = "Omeromer1950";
                WebMail.SmtpPort = 587;
                WebMail.Send("info@componentcomparecenter.com.tr", adsoyad, konu + "<br/> Gönderen Mail Adresi : " + email + "<br/> İletilen Mesaj : " + mesaj);


            }
            return View();
        }



        public ActionResult Destek()
        {
            return View(c.Desteks.ToList().OrderByDescending(x => x.Id));
        }
        //public ActionResult Iletisim()
        //{
        //    return View(c.Iletisims.FirstOrDefault());
        //}
        //Anakart Yorum

        //public JsonResult YorumYap(string adsoyad, string icerik, int urunid)
        //{
        //    if (icerik == null)
        //    {
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }
        //    c.Yorums.Add(new Yorum { UyeAdSoyad = adsoyad, aciklama = icerik, Urunid = urunid, Onay = false });
        //    c.SaveChanges();

        //    return Json(false, JsonRequestBehavior.AllowGet);
        //}
    }
}