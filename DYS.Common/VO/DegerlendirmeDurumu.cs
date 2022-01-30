using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DYS.Common.VO
{
	public class DegerlendirmeDurumu:BaseEntity
	{
		[Key]
		public int Id { get; set; }
        [ForeignKey("Proje")]
        public int? ProjeId { get; set; }

        public int AtayanKullaniciId { get; set; }
		[ForeignKey("Kullanici")]
		public int KullaniciId { get; set; }

		[ForeignKey("Gorev")]
		public int GorevId { get; set; }

		public double? Puan { get; set; }

		
		[StringLength(500)]
		public string IlerlemeDurumAdi { get; set; }
        public bool Aktif { get; set; }

		public virtual Kullanici Kullanici { get; set; }
        public virtual Kullanici AtayanKullanici { get; set; }

		public virtual Gorev Gorev { get; set; }
        public virtual Proje Proje { get; set; }


    }
}
