using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class CompareBasket //sepetin tamamını temsil ediyor
    {
        private List<CompareBasketLine> _combareBasketLines = new List<CompareBasketLine>();
        public List<CompareBasketLine> CombareBasketLines
        {
            get{ return _combareBasketLines; }
        }
        public void AddUrun(AnakartOzellik urun, int quantity)
        {
            var line = _combareBasketLines.FirstOrDefault(i => i.Urun.ID == urun.ID);
            if (line==null)//burada seçilen üründen bir tane daha varsa ürün sayısını bir arttırıcak (biz böyle olsamını istemiyoruz bir üründen sadece bir tane eklenebilir olsun istiyoruz)
            {
                _combareBasketLines.Add(new CompareBasketLine() { Urun = urun, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity; //biz büyük ihtimallle bu kısmı değitirip bir uyarı vericez ama sanırım
            }

        }

        public void DeleteUrun(AnakartOzellik urun)
        {
            _combareBasketLines.RemoveAll(i => i.Urun.ID==urun.ID) ;
        }

        public void Clear()
        {
            _combareBasketLines.Clear();
        }

    }
    public class CompareBasketLine
    {
        public AnakartOzellik Urun { get; set; }
        public int Quantity { get; set; } //her bir satırı temsil ediyor 


    }
}