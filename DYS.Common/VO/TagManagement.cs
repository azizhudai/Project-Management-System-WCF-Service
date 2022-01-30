using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
	public class TagManagement:BaseEntity
	{
		public int Id { get; set; }
		[StringLength(50)]
		public string TagName { get; set; }
        [ForeignKey("Kullanici")]
		public int? UserId { get; set; }
        [ForeignKey("Gorev")]
        public int TaskId { get; set; }
		public bool? IsActive { get; set; }
	    public virtual Kullanici Kullanici { get; set; }
        public virtual Gorev Gorev { get; set; }
        public TagManagement()
		{
		}
	}
}
