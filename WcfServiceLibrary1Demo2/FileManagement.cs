namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FileManagement")]
    public partial class FileManagement
    {
        [Key]
        public int FileId { get; set; }

        [Required]
        [StringLength(100)]
        public string FileTitle { get; set; }

        [Required]
        [StringLength(100)]
        public string FilePath { get; set; }

        public int? FolderId { get; set; }

        public bool IsActive { get; set; }
    }
}
