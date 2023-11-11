using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class AnakartOzellik
    {
        [Key]
        public int ID { get; set; }
        public decimal Fiyat { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string YongaSetiModeli { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "30 karekter olmadır")]
        public string FormFaktor { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "10 karekter olmadır")]
        public string IslemciSoketi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string BellekTeknolojisi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string BellekSaatHizi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string BellekKanali { get; set; }
        public bool M2Yuvasi { get; set; }
        public bool HizAsirtma { get; set; } //(Overclock)
        public bool Bluetooth{ get; set; }
        public bool Aydınlatma { get; set; }
        public bool WiFi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(4, ErrorMessage ="4 karekter olmadır")]
        public string CikisYili { get; set; }
        public byte TeknikPuan { get; set; }
        public virtual Urun Uruns { get; set; }
        public int Urunid { get; set; }
    }
}