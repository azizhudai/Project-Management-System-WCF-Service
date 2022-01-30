namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SayfaAltYetkiler")]
    public partial class SayfaAltYetkiler
    {
        [Key]
        public long SayfaAltYetkiId { get; set; }

        public int SayfaIslemlerId { get; set; }

        public int RolId { get; set; }

        public bool Aktif { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual SayfaIslemler SayfaIslemler { get; set; }
    }
}
