using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ComponentCompareCenter.Models.Siniflar
{
    public class Context: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<MonitorOzellik> MonitorOzelliks { get; set; }
        public DbSet<AnakartOzellik> AnakartOzelliks { get; set; }
        public DbSet<EkranKartiOzellik> EkranKartiOzelliks { get; set; }
        public DbSet<IslemciOzellik> IslemciOzelliks { get; set; }
        public DbSet<PowerSuppleyOzellik> PowerSupplyOzelliks { get; set; }
        public DbSet<RAMOzellik> RAMOzelliks { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Uye> Uyes { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Destek> Desteks { get; set; }
    }
}