namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FolderManagement")]
    public partial class FolderManagement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FolderManagement()
        {
            FolderManagement1 = new HashSet<FolderManagement>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int? ParentId { get; set; }

        public bool IsActive { get; set; }

        public bool FolderType { get; set; }

        [StringLength(100)]
        public string Path { get; set; }

        [StringLength(50)]
        public string FileContentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FolderManagement> FolderManagement1 { get; set; }

        public virtual FolderManagement FolderManagement2 { get; set; }
    }
}
