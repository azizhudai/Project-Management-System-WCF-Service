using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DYS.Common.VO
{
	public partial class ReportManagement:BaseEntity
	{
		public int Id { get; set; }

		[StringLength(100)]
		public string ReportName { get; set; }
        [ForeignKey("Gorev")]
		public int? TaskId { get; set; }
        [ForeignKey("Kullanici")]
		public int? UserId { get; set; }
        
		[StringLength(100)]
		[AllowHtml]
		public string Explain { get; set; }
        [ForeignKey("TagManagement")]
		public int? TagId { get; set; }

		public bool? IsActive { get; set; }

        public virtual Gorev Gorev { get; set; }
	    public virtual Kullanici Kullanici { get; set; }
        public virtual TagManagement TagManagement { get; set; }
        public ReportManagement()
		{
		}
	}
}
