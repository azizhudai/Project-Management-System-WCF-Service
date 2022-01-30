using System.ComponentModel.DataAnnotations;

namespace DYS.Common.VO
{
	public class Sayfalar : BaseEntity
	{
		[Key]
		public int SayfaId { get; set; }

		[Required(ErrorMessage = "*Zorunlu.")]
		[StringLength(100, ErrorMessage = "*En fazla 100 karakter.")]
		public string Ad { get; set; }

		[StringLength(100, ErrorMessage = "*En fazla 100 karakter.")]
		public string Name { get; set; }

		[StringLength(100, ErrorMessage = "*En fazla 100 karakter.")]
		public string ControllerAdi { get; set; }

		[StringLength(100, ErrorMessage = "*En fazla 100 karakter.")]
		public string ActionAdi { get; set; }

		[Required(ErrorMessage = "*Zorunlu.")]
		public bool Aktif { get; set; }

		[StringLength(255, ErrorMessage = "*En fazla 255 karakter.")]
		public string FotografYolu { get; set; }

		[Required(ErrorMessage = "*Zorunlu.")]
		public bool UstBaslik { get; set; }

		public int? UstId { get; set; }

		public int? Sira { get; set; }

	}
}
