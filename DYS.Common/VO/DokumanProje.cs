using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
	public  class DokumanProje:BaseEntity
	{
		[Key]
		public int Id { get; set; }

		[StringLength(50)]
		public string Turu { get; set; }

		[ForeignKey("Proje")]
		public int ProjeId { get; set; }

		public virtual Proje Proje { get; set; }

		
	}
}
