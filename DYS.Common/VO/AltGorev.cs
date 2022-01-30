using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DYS.Common.VO
{
	public class AltGorev:BaseEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(500)]
		public string Adi { get; set; }

		[Required]
		[StringLength(10)]
		public string Durum { get; set; }

		[ForeignKey("Gorev")]
		public int? GorevId { get; set; }

		public int? Sira { get; set; }

		public virtual Gorev Gorev { get; set; }


	}
}
