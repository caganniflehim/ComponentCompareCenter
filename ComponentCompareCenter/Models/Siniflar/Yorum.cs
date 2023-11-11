using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class Yorum
    {
        [Key]
        public int yorumID { get; set; }
        public Urun Urun { get; set; }
        public Uye Uye { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250, ErrorMessage = "250 karekter olmadır")]
        public string aciklama { get; set; }
        public byte puan { get; set; }
        public DateTime yorumTarihi { get; set; }

    }
}