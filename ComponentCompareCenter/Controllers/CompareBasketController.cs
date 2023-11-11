using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComponentCompareCenter.Models.Siniflar;

namespace ComponentCompareCenter.Controllers
{
    public class CompareBasketController : Controller
    {
        // GET: CompareBasket
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            return View(GetCompareBasket());
        }
        public ActionResult AddCompareBasket(int? urunid)
        {
            var urun = c.AnakartOzelliks.FirstOrDefault(i => i.ID == urunid);

            if (urun!=null) //Kullanıcının eklediği ürün veritabanında varsa
            {
                GetCompareBasket().AddUrun(urun, 1);
            }

            return RedirectToAction("Index");
        }
        public ActionResult RemoveCompareBasket(int? urunid)
        {
            var urun = c.AnakartOzelliks.FirstOrDefault(i => i.ID == urunid);

            if (urun != null) 
            {
                GetCompareBasket().DeleteUrun(urun);
            }

            return RedirectToAction("Index");
        }
        public CompareBasket GetCompareBasket()//siteyi ziyaret eden Kuullanıcılar için oluşturuyoruz bunu
        {
            var compareBasket = (CompareBasket)Session["CompareBasket"]; //Ahmet benim sitemi ziyaret etti Ahmet için yeni bir Comparebasket oluşturup göndericem. Bu Comparebasket saklamak için Sesison kullandık.Session kullanıcıya özel depo oluşturur.
            
            if (compareBasket==null)  //Kartın kopyasını oluşturuyotuz Ahmet bir dahaki geldiğinde session oluşturmuyoruz sakladığımız sessionu kullanıyoruz
            { 
                compareBasket = new CompareBasket();
                Session["CompareBasket"] = compareBasket;
            }
            return compareBasket;
        }
    }
}