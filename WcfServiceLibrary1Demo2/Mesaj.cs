namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mesaj")]
    public partial class Mesaj
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string MesajAdi { get; set; }

        public int? ProjeId { get; set; }

        public int KullaniciId { get; set; }

        public int? GonderenKullaniciId { get; set; }

        [Column(TypeName = "date")]
        public DateTime GelisTarihi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? GonderenGelisTarihi { get; set; }

        public int? ProjectMessageId { get; set; }

        public bool? Aktif { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Proje Proje { get; set; }

        public virtual ProjectMessage ProjectMessage { get; set; }
    }
}
