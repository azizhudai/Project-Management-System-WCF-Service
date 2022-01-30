using System.ComponentModel.DataAnnotations;

namespace DYS.Common.VO
{
	public class Rol : BaseEntity
	{
		[Key]
		public int RolId { get; set; }

		[Required(ErrorMessage = "*Zorunlu.")]
		[StringLength(100, ErrorMessage = "*En fazla 100 karakter.")]
		public string Ad { get; set; }

		[StringLength(100, ErrorMessage = "*En fazla 100 karakter.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "*Zorunlu.")]
		public bool Aktif { get; set; }

		public byte? Tipi { get; set; }

	}
}
