using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComponentCompareCenter.Models.Siniflar;

namespace ComponentCompareCenter.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deger1 = c.Kategoris.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Markas.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.AnakartOzelliks.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.MonitorOzelliks.Count().ToString();
            ViewBag.d5 = deger5;

            var deger6 = c.EkranKartiOzelliks.Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = c.RAMOzelliks.Count().ToString();
            ViewBag.d7 = deger7;

            var deger8 = c.IslemciOzelliks.Count().ToString();
            ViewBag.d8 = deger8;

            var deger9 = c.PowerSupplyOzelliks.Count().ToString();
            ViewBag.d9 = deger9;
            return View();
        }
    }
}