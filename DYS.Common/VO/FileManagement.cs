using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
	public class FileManagement:BaseEntity
	{
	    [Key]
		public int FileId { get; set; }

		[Required]
		[StringLength(100)]
		public string FileTitle { get; set; }

		[Required]
		[StringLength(100)]
		public string FilePath { get; set; }

		[ForeignKey("FolderManagement")]
		public int? FolderId { get; set; }

		public bool IsActive { get; set; }

		public virtual FolderManagement FolderManagement { get; set; }

		
	}
}
