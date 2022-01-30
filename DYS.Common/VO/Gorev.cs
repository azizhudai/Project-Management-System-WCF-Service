using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
	public class Gorev : BaseEntity
	{
		[Key]
		public int GorevId { get; set; }

		[Required]
		[StringLength(500)]
		public string GorevAdi { get; set; }

		public bool Aktif { get; set; }

		public bool AktifBitmedi { get; set; }

		[StringLength(20)]
		public string GorevOncelik { get; set; }

		public DateTime GorevBaslangic { get; set; }

		public DateTime GorevBitis { get; set; }
        [Required(ErrorMessage = "*Zorunlu.")]
        [ForeignKey("Kullanici")]
        public int? KullaniciId { get; set; }

       
        [Required(ErrorMessage = "*Zorunlu.")]
        [ForeignKey("Proje")]
		public int ProjeId { get; set; }
        public string GorevAciklama { get; set; }
        public int Sira { get; set; }
        public bool GizlilikAktif { get; set; }
        public DateTime SistemBaslamaTarihi {get; set; }

        public virtual Proje Proje { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        //public virtual ICollection<DegerlendirmeDurumu> DegerlendirmeDurumus { get; set; }
		
	}
}
