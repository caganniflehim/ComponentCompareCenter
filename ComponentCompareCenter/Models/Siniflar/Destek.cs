using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class Destek
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(5000, ErrorMessage = "5000 karekter olmadır")]
        public string sorular { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(5000, ErrorMessage = "5000 karekter olmadır")]
        public string cevaplar { get; set; }
    }
}