using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ComponentCompareCenter.Models.Siniflar;

namespace ComponentCompareCenter.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var slider = c.Sliders.ToList();
            return View(slider);
        }

        [HttpGet]
        public ActionResult SliderEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SliderEkle(Slider s)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/SliderImage/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                s.Gorsel = "/SliderImage/" + dosyaadi + uzanti;
            }

            c.Sliders.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SliderSil(int id)
        {
            var slider = c.Sliders.Find(id);
            c.Sliders.Remove(slider);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SliderGetir(int id)
        {
            var sli = c.Sliders.Find(id);
            return View("SliderGetir", sli);
        }

        [ValidateInput(false)]
        public ActionResult SliderGuncelle(int? id, Slider slider, HttpPostedFileBase sliderimage)
        {
            if (ModelState.IsValid)
            {
                var a = c.Sliders.Where(x => x.SliderId == id).SingleOrDefault();

                if (sliderimage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(a.Gorsel)))
                    {
                        System.IO.File.Delete(Server.MapPath(a.Gorsel));
                    }

                    WebImage img = new WebImage(sliderimage.InputStream);
                    FileInfo imginfo = new FileInfo(sliderimage.FileName);

                    string slidername = sliderimage.FileName + imginfo.Extension;
                    img.Resize(200, 100);
                    img.Save("~/Images/" + slidername);
                    a.Gorsel = "/Images/" + slidername;
                }

                a.Baslik = slider.Baslik;
                a.Aciklama = slider.Aciklama;
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
