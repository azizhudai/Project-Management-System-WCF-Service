namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rol")]
    public partial class Rol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rol()
        {
            Kullanici = new HashSet<Kullanici>();
            SayfaAltYetkiler = new HashSet<SayfaAltYetkiler>();
            SayfaYetkiler = new HashSet<SayfaYetkiler>();
        }

        public int RolId { get; set; }

        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool Aktif { get; set; }

        public byte? Tipi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanici> Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SayfaAltYetkiler> SayfaAltYetkiler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SayfaYetkiler> SayfaYetkiler { get; set; }
    }
}
