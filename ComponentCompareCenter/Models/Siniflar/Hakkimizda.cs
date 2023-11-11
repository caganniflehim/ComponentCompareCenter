using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace ComponentCompareCenter.Models.Siniflar
{
    public class Hakkimizda
    {
        [Key]
        public byte Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(5000, ErrorMessage = "300 karekter olmadır")]
        public string Açıklama { get; set; }
    }
}