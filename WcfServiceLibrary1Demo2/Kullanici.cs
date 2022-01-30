namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            DegerlendirmeDurumu = new HashSet<DegerlendirmeDurumu>();
            Gorev = new HashSet<Gorev>();
            Mesaj = new HashSet<Mesaj>();
            Proje = new HashSet<Proje>();
            UserFriend = new HashSet<UserFriend>();
            UserFriend1 = new HashSet<UserFriend>();
        }

        public int KullaniciId { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        [Required]
        [StringLength(100)]
        public string Sifre { get; set; }

        [Required]
        [StringLength(130)]
        public string EMail { get; set; }

        public int RoleId { get; set; }

        public bool Aktif { get; set; }

        [StringLength(12)]
        public string Telefon { get; set; }

        [StringLength(500)]
        public string ResimYolu { get; set; }

        [StringLength(50)]
        public string SirketAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DegerlendirmeDurumu> DegerlendirmeDurumu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gorev> Gorev { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mesaj> Mesaj { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proje> Proje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFriend> UserFriend { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFriend> UserFriend1 { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
