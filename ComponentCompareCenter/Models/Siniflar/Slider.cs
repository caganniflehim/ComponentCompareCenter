using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "30 karekter olmadır")]
        public string Baslik { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(150, ErrorMessage = "150 karekter olmadır")]
        public string Aciklama { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250, ErrorMessage = "250 karekter olmadır")]
        public string Gorsel { get; set; }
    }
}

