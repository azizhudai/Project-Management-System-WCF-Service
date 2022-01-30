using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
	public class FolderManagement:BaseEntity
	{
	    [Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Title { get; set; }
     
		public int? ParentId { get; set; }

		public bool IsActive { get; set; }
        public bool FolderType { get; set; }
        public string Path { get; set; }
        public string FileContentType { get; set; }


	}
}
