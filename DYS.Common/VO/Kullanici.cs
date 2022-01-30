using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
    public class Kullanici : BaseEntity
    {
        [Key]
        public int KullaniciId { get; set; }

        [Required(ErrorMessage = "*Zorunlu.")]
        [StringLength(100, ErrorMessage = "*En fazla 100 karakter.")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "*Zorunlu.")]
        [StringLength(50, ErrorMessage = "*En fazla 50 karakter.")]
        public string Ad { get; set; }

        [StringLength(50, ErrorMessage = "*En fazla 50 karakter.")]

        public string Soyad { get; set; }

        [Required(ErrorMessage = "*Zorunlu.")]
        [StringLength(130, ErrorMessage = "*En fazla 130 karakter.")]
        public string EMail { get; set; }

      //  [Required(ErrorMessage = "*Zorunlu.")]
        [StringLength(50, ErrorMessage = "*En fazla 50 karakter.")]
        public string SirketAdi { get; set; }

        [ForeignKey("Rol")]
        [Required(ErrorMessage = "*Zorunlu.")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "*Zorunlu.")]
        public bool Aktif { get; set; }

        [StringLength(12, ErrorMessage = "*En fazla 12 karakter.")]
        public string Telefon { get; set; }

        [StringLength(500, ErrorMessage = "*En fazla 500 karakter.")]
        public string ResimYolu { get; set; }
        [StringLength(500, ErrorMessage = "*En fazla 500 karakter.")]
        public string TokenId { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual ICollection<UserFriend> User { get; set; }
        public virtual ICollection<UserFriend> UserJobFriend { get; set; }
        public virtual ICollection<Mesaj> GonderenKullanici { get; set; }
        public virtual ICollection<DegerlendirmeDurumu> UserAppoint { get; set; }

    }
}
