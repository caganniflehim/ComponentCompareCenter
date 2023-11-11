using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ComponentCompareCenter.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace ComponentCompareCenter.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Uruns.ToList().ToPagedList(sayfa, 6); ;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {

          

            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Markas.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.MarkaAd,
                                               Value = x.MarkaID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun r)
        {

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                r.urunGorsel = "/Images/" + dosyaadi + uzanti;


            }


            c.Uruns.Add(r);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urun = c.Uruns.Find(id);
            c.Uruns.Remove(urun);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = c.Uruns.Find(id);
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Markas.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.MarkaAd,
                                               Value = x.MarkaID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            return View("UrunGetir", urun);
        }

        [ValidateInput(false)]
        public ActionResult UrunGuncelle(int? id, Urun urun, HttpPostedFileBase urunimage)
        {
            if (ModelState.IsValid)
            {
                var a = c.Uruns.Where(x => x.UrunID == id).SingleOrDefault();

                if (urunimage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(a.urunGorsel)))
                    {
                        System.IO.File.Delete(Server.MapPath(a.urunGorsel));
                    }

                    WebImage img = new WebImage(urunimage.InputStream);
                    FileInfo imginfo = new FileInfo(urunimage.FileName);

                    string urunname = urunimage.FileName + imginfo.Extension;
                    img.Resize(200, 100);
                    img.Save("~/Images/" + urunname);
                    a.urunGorsel = "/Images/" + urunname;
                }

                a.UrunAd = urun.UrunAd;

                a.Kategoriid = urun.Kategoriid;
                a.Markaid = urun.Markaid;
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        //public ActionResult UrunGuncelle(Urun u)
        //{
        //    var uyg = c.Uruns.Find(u.UrunID);
        //    uyg.UrunAd = u.UrunAd;
        //    uyg.urunGorsel = u.urunGorsel;
        //    uyg.Kategori = u.Kategori;
        //    uyg.MarkaAd = u.MarkaAd;
        //    c.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}