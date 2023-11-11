using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class Uye
    {
        [Key]
        public int uyeID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "30 karekter olmadır")]
        public string uyeAd { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "30 karekter olmadır")]
        public string uyeSoyad { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(150, ErrorMessage = "150 karekter olmadır")]
        public string uyeAdresi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "30 karekter olmadır")]
        public string uyeEposta { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(11, ErrorMessage = "11 karekter olmadır")]
        public string uyeTelNo { get; set; }

        public ICollection<Yorum> Yorums { get; set; }
    }
}