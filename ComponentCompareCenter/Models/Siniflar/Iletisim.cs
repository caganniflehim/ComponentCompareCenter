using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class Iletisim
    {
        [Key]
        public int IletisimID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(200, ErrorMessage = "200 karekter olmadır")]
        public string Adres { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(11, ErrorMessage = "11 karekter olmadır")]
        public string Telefon { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100, ErrorMessage = "100 karekter olmadır")]
        public string Mail { get; set; }
    }
}