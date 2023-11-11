using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100, ErrorMessage = "100 karekter olmadır")]
        public string UrunAd { get; set; }
        //bir markada birden fazla ürün olabilir.
        public virtual Marka MarkaAd { get; set; }
        public int Markaid { get; set; }
        public ICollection<MonitorOzellik> MonitorOzellik { get; set; }
        public ICollection<AnakartOzellik> AnakartOzellik { get; set; }
        public ICollection<EkranKartiOzellik> EkranKartiOzellik { get; set; }
        public ICollection<IslemciOzellik> IslemciOzellik { get; set; }
        public ICollection<PowerSuppleyOzellik> PowerSupplyOzellik { get; set; }
        public ICollection<RAMOzellik> RAMOzellik { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250, ErrorMessage = "250 karekter olmadır")]
        public string urunGorsel { get; set; }
        //bir kategoride birden fazla ürün olabilir.
        public virtual Kategori Kategori { get; set; }
        public int Kategoriid { get; set; }
        
        public ICollection<Yorum> Yorums { get; set; }


    }
}