using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComponentCompareCenter.Models.Siniflar;

namespace ComponentCompareCenter.Controllers
{
    public class HakkimizdaController : Controller
    {
        // GET: Hakkimizda
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var h = c.Hakkimizdas.ToList();
            return View(h);
        }

        [HttpGet]
        public ActionResult HakkimizdaGetir(int id)
        {
            var h = c.Hakkimizdas.Where(x => x.Id == id).FirstOrDefault();
            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult HakkimizdaGetir(int id, Hakkimizda h)
        {
            if (ModelState.IsValid)
            {
                var hakk = c.Hakkimizdas.Where(x => x.Id == id).SingleOrDefault();

                hakk.Açıklama = h.Açıklama;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h);
        }
    }
}