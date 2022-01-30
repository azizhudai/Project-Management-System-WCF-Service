namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SayfaYetkiler")]
    public partial class SayfaYetkiler
    {
        [Key]
        public long SayfaYetkiId { get; set; }

        public int SayfaId { get; set; }

        public int RolId { get; set; }

        public bool Aktif { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual Sayfalar Sayfalar { get; set; }
    }
}
