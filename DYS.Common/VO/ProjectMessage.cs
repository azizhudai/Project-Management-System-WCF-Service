using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DYS.Common.VO
{
    public class ProjectMessage: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Proje")]
        public int? ProjectId { get; set; }
        public string ProjectConversation {get;set;}
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Proje Proje { get; set; }
    }
}
