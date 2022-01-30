using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DYS.Common.VO
{
	public  class DokumanGorev:BaseEntity
	{
		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Turu { get; set; }

		[ForeignKey("Gorev")]
		public int? GorevId { get; set; }

		public virtual Gorev Gorev { get; set; }

	}
}
