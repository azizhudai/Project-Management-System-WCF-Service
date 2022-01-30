namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SayfaIslemler")]
    public partial class SayfaIslemler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SayfaIslemler()
        {
            SayfaAltYetkiler = new HashSet<SayfaAltYetkiler>();
        }

        public int SayfaIslemlerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int SayfaId { get; set; }

        public bool Aktif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SayfaAltYetkiler> SayfaAltYetkiler { get; set; }

        public virtual Sayfalar Sayfalar { get; set; }
    }
}
