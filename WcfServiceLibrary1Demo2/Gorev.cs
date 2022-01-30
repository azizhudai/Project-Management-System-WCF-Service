namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gorev")]
    public partial class Gorev
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gorev()
        {
            AltGorev = new HashSet<AltGorev>();
            DegerlendirmeDurumu = new HashSet<DegerlendirmeDurumu>();
            DokumanGorev = new HashSet<DokumanGorev>();
        }

        public int GorevId { get; set; }

        [Required]
        [StringLength(500)]
        public string GorevAdi { get; set; }

        public bool Aktif { get; set; }

        public bool AktifBitmedi { get; set; }

        [StringLength(20)]
        public string GorevOncelik { get; set; }

        [Column(TypeName = "date")]
        public DateTime? GorevBaslangic { get; set; }

        [Column(TypeName = "date")]
        public DateTime? GorevBitis { get; set; }

        public int ProjeId { get; set; }

        [StringLength(500)]
        public string GorevAciklama { get; set; }

        public int? KullaniciId { get; set; }

        public int? Sira { get; set; }

        public bool? GizlilikAktif { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SistemBaslamaTarihi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AltGorev> AltGorev { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DegerlendirmeDurumu> DegerlendirmeDurumu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DokumanGorev> DokumanGorev { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Proje Proje { get; set; }
    }
}
