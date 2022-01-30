namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetayliDegerlendirme")]
    public partial class DetayliDegerlendirme
    {
        public int DetayliDegerlendirmeId { get; set; }

        [Required]
        [StringLength(50)]
        public string DetayliDegerlendirmeAdi { get; set; }

        public int DetayliPuan { get; set; }

        public int DegerlendirmeDurumuId { get; set; }

        public bool Aktif { get; set; }

        public virtual DegerlendirmeDurumu DegerlendirmeDurumu { get; set; }
    }
}
