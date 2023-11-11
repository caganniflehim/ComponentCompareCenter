using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class IslemciOzellik
    {
        [Key]
        public int ID { get; set; }
        public decimal Fiyat { get; set; }
        public int Cekirdek { get; set; }
        public int SanalCekirdek { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string TemelFrekans { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string BellekTuru { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100, ErrorMessage = "100 karekter olmadır")]
        public string Soket { get; set; }
        public bool DahiliGrafikIslemci { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string OnBellek { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "50 karekter olmadır")]
        public string IslenciSerisi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(75, ErrorMessage = "75 karekter olmadır")]
        public string Jenerasyon { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(75, ErrorMessage = "75 karekter olmadır")]
        public string IslemciMimarisi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(4, ErrorMessage = "4 karekter olmadır")]
        public string CikisYili { get; set; }
        public byte TeknikPuan { get; set; }
        public virtual Urun Uruns { get; set; }
        public int Urunid { get; set; }

    }
}