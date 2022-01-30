namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectMessage")]
    public partial class ProjectMessage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectMessage()
        {
            Mesaj = new HashSet<Mesaj>();
        }

        public int Id { get; set; }

        public int? ProjectId { get; set; }

        [StringLength(50)]
        public string ProjectConversation { get; set; }

        public DateTime? StartDate { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mesaj> Mesaj { get; set; }

        public virtual Proje Proje { get; set; }
    }
}
