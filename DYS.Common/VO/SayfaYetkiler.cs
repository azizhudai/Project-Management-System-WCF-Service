using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
	public class SayfaYetkiler : BaseEntity
	{
		[Key]
		public long SayfaYetkiId { get; set; }

		[ForeignKey("Sayfalar")]
		[Required(ErrorMessage = "*Zorunlu.")]
		public int SayfaId { get; set; }

		[ForeignKey("Rol")]
		[Required(ErrorMessage = "*Zorunlu.")]
		public int RolId { get; set; }

		[Required(ErrorMessage = "*Zorunlu.")]
		public bool Aktif { get; set; }

		public virtual Sayfalar Sayfalar { get; set; }

		public virtual Rol Rol { get; set; }

	}
}
