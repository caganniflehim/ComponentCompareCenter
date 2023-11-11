using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class EkranKartiOzellik
    {
        [Key]
        public int ID { get; set; }
        public decimal Fiyat { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "15 karekter olmadır")]
        public string İşlemciÜretici { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string BellekBoyutu { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "15 karekter olmadır")]
        public string BellekTürü { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "15 karekter olmadır")]
        public string GPUÇekirdek { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string GrafikKartıGücü { get; set; }
        public bool VRDestegi { get; set; }
        public bool ÇokluGPU { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "15 karekter olmadır")]
        public string BaglantiArayuz { get; set; }
        public bool DisplayPort { get; set; }
        public bool HDMI { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "15 karekter olmadır")]
        public string SogutmaTipi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "15 karekter olmadır")]
        public string FanSayısı { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "30 karekter olmadır")]
        public string Grafikİslemci { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "15 karekter olmadır")]
        public string İslemciÜretici { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "15 karekter olmadır")]
        public string GPUMimarisi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "15 karekter olmadır")]
        public string Directx { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(4, ErrorMessage = "4 karekter olmadır")]
        public string CikisYili { get; set; }
        public byte TeknikPuan { get; set; }
        public virtual Urun Uruns { get; set; }
        public int Urunid { get; set; }
    }
}