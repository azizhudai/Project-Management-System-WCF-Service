using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
	public class DetayliDegerlendirme:BaseEntity
	{
		[Key]
		public int DetayliDegerlendirmeId { get; set; }

		[Required]
		[StringLength(50)]
		public string DetayliDegerlendirmeAdi { get; set; }

		public int DetayliPuan { get; set; }

		[ForeignKey("DegerlendirmeDurumu")]
		public int DegerlendirmeDurumuId { get; set; }

		public bool Aktif { get; set; }

		public virtual DegerlendirmeDurumu DegerlendirmeDurumu { get; set; }

		
	}
}
