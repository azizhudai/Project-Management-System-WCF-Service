using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
	public class SayfaAltYetkiler : BaseEntity
	{
		[Key]
		public long SayfaAltYetkiId { get; set; }

		[ForeignKey("SayfaIslemler")]
		[Required(ErrorMessage = "*Zorunlu.")]
		public int SayfaIslemlerId { get; set; }

		[ForeignKey("Rol")]
		[Required(ErrorMessage = "*Zorunlu.")]
		public int RolId { get; set; }

		[Required(ErrorMessage = "*Zorunlu.")]
		public bool Aktif { get; set; }

		public virtual SayfaIslemler SayfaIslemler { get; set; }

		public virtual Rol Rol { get; set; }

	}
}
