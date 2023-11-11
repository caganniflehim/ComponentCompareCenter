using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web; 


namespace ComponentCompareCenter.Models.Siniflar
{
    public class MonitorOzellik
    {
        [Key]
        public int ID { get; set; }
        public decimal Fiyat { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string EkranBoyutu { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string YenilemeHizi{ get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "30 karekter olmadır")]
        public string EkranCozunurlugu { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "15 karekter olmadır")]
        public string EkranTeknolojisi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "30 karekter olmadır")]
        public string TepkiSuresi { get; set; }
        public bool HDMI { get; set; }
        public bool DisplayPort { get; set; }
        public bool Hoperlor { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(4, ErrorMessage = "4 karekter olmadır")]
        public string CikisYili { get; set; }
        public byte TeknikPuan { get; set; }
        public virtual Urun Uruns { get; set; }
        public int Urunid { get; set; }

    }
}