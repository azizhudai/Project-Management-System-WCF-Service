using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
	public class SayfaIslemler : BaseEntity
	{
		[Key]
		public int SayfaIslemlerId { get; set; }

		[Required(ErrorMessage = "*Zorunlu.")]
		[StringLength(100, ErrorMessage = "*En fazla 100 karakter.")]
		public string Ad { get; set; }

		[StringLength(100, ErrorMessage = "*En fazla 100 karakter.")]
		public string Name { get; set; }

		[ForeignKey("Sayfalar")]
		[Required(ErrorMessage = "*Zorunlu.")]
		public int SayfaId { get; set; }

		[Required(ErrorMessage = "*Zorunlu.")]
		public bool Aktif { get; set; }

		public virtual Sayfalar Sayfalar { get; set; }

	}
}
