using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class RAMOzellik
    {
        [Key]
        public int ID { get; set; }
        public decimal Fiyat { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string BellekHizi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string BellekKapasitesi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string BellekTeknoloji { get; set; }
        public byte TepkimeSuresi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string BellekSayisi { get; set; }
        public bool Sogutucu { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(75, ErrorMessage = "75 karekter olmadır")]
        public string UrunAilesi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "30 karekter olmadır")]
        public string UrunSerisi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "15 karekter olmadır")]
        public string Platform { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(4, ErrorMessage = "4 karekter olmadır")]
        public string CikisYili { get; set; }
        public byte TeknikPuan { get; set; }
        public virtual Urun Uruns { get; set; }
        public int Urunid { get; set; }
    }
}