using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DYS.Common.VO
{
	public class Mesaj:BaseEntity
	{
		[Key]
		public int Id { get; set; }
        [ForeignKey("ProjectMessage")]
        public int ProjectMessageId { get; set; }

		[StringLength(500)]
		public string MesajAdi { get; set; }

		[ForeignKey("Proje")]
		public int? ProjeId { get; set; }

		[ForeignKey("Kullanici")]
		public int KullaniciId { get; set; }
        public int? GonderenKullaniciId { get; set; }

        public DateTime GelisTarihi { get; set; }
        public DateTime? GonderenGelisTarihi { get; set; }
        public bool Aktif { get; set; }
        public virtual Proje Proje { get; set; }

        public virtual ProjectMessage ProjectMessage { get; set; }
		public virtual Kullanici Kullanici { get; set; }
        public virtual Kullanici GonderenKullanici { get; set; }

	
	}
}
