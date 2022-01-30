using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
	public class Proje : BaseEntity
	{
		[Key]
		public int ProjeId { get; set; }

        [Required(ErrorMessage = "*Zorunlu.")]
		[StringLength(130)]
		public string ProjeAdi { get; set; }
        public string ProjeAciklama { get; set; }
        [Required(ErrorMessage = "*Zorunlu.")]
		public bool Aktif { get; set; }

		public bool AktifBitmedi { get; set; }
        [Required(ErrorMessage = "*Zorunlu.")]
        [ForeignKey("Kullanici")]
        public int YoneticiKullaniciId { get; set; }
        public int Sira { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public DateTime SistemBaslamaTarihi { get; set; }
        public bool GizlilikAktif { get; set; }
        public virtual Kullanici Kullanici { get; set; }

        public virtual ICollection<Gorev> Gorevs { get; set; }
        public virtual ICollection<DegerlendirmeDurumu> DegerlendirmeDurumus { get; set; }
       
		}
}
