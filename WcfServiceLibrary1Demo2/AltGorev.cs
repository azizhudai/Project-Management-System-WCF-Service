namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AltGorev")]
    public partial class AltGorev
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Adi { get; set; }

        [Required]
        [StringLength(10)]
        public string Durum { get; set; }

        public int? GorevId { get; set; }

        public int? Sira { get; set; }

        public virtual Gorev Gorev { get; set; }
    }
}
