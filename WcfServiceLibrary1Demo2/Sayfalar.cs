namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sayfalar")]
    public partial class Sayfalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sayfalar()
        {
            SayfaIslemler = new HashSet<SayfaIslemler>();
            SayfaYetkiler = new HashSet<SayfaYetkiler>();
        }

        [Key]
        public int SayfaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string ControllerAdi { get; set; }

        [StringLength(100)]
        public string ActionAdi { get; set; }

        public bool Aktif { get; set; }

        [StringLength(255)]
        public string FotografYolu { get; set; }

        public bool UstBaslik { get; set; }

        public int? UstId { get; set; }

        public int? Sira { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SayfaIslemler> SayfaIslemler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SayfaYetkiler> SayfaYetkiler { get; set; }
    }
}
