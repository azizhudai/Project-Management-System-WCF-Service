namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proje")]
    public partial class Proje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proje()
        {
            DegerlendirmeDurumu = new HashSet<DegerlendirmeDurumu>();
            DokumanProje = new HashSet<DokumanProje>();
            Gorev = new HashSet<Gorev>();
            Mesaj = new HashSet<Mesaj>();
            ProjectMessage = new HashSet<ProjectMessage>();
        }

        public int ProjeId { get; set; }

        [Required]
        [StringLength(130)]
        public string ProjeAdi { get; set; }

        public bool Aktif { get; set; }

        public bool AktifBitmedi { get; set; }

        public int YoneticiKullaniciId { get; set; }

        public int? Sira { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BaslangicTarihi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BitisTarihi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SistemBaslamaTarihi { get; set; }

        public bool? GizlilikAktif { get; set; }

        [StringLength(500)]
        public string ProjeAciklama { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DegerlendirmeDurumu> DegerlendirmeDurumu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DokumanProje> DokumanProje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gorev> Gorev { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mesaj> Mesaj { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectMessage> ProjectMessage { get; set; }
    }
}
