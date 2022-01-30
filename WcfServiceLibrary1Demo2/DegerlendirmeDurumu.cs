namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DegerlendirmeDurumu")]
    public partial class DegerlendirmeDurumu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DegerlendirmeDurumu()
        {
            DetayliDegerlendirme = new HashSet<DetayliDegerlendirme>();
        }

        public int Id { get; set; }

        public int AtayanKullaniciId { get; set; }

        public int KullaniciId { get; set; }

        public int GorevId { get; set; }

        public double Puan { get; set; }

        [StringLength(500)]
        public string IlerlemeDurumAdi { get; set; }

        public bool? Aktif { get; set; }

        public int? ProjeId { get; set; }

        public virtual Gorev Gorev { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Proje Proje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetayliDegerlendirme> DetayliDegerlendirme { get; set; }
    }
}
