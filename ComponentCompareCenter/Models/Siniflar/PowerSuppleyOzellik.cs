using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace ComponentCompareCenter.Models.Siniflar
{
    public class PowerSuppleyOzellik
    {
        [Key]
        public int ID { get; set; }
        public decimal Fiyat { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string Guc { get; set; }
        public byte GucVerimliligi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "30 karekter olmadır")]
        public string KabloTipi { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "10 karekter olmadır")]
        public string FanBoyutu { get; set; }
        public bool PFC { get; set; }
        public bool Anahtar { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20, ErrorMessage = "20 karekter olmadır")]
        public string Model { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(4, ErrorMessage = "4 karekter olmadır")]
        public string CikisYili { get; set; }
        public byte TeknikPuan { get; set; }
        public virtual Urun Uruns { get; set; }
        public int Urunid { get; set; }
    }
}