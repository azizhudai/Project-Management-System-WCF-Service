namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DokumanProje")]
    public partial class DokumanProje
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Turu { get; set; }

        public int ProjeId { get; set; }

        public byte[] ProjeDokumanlar { get; set; }

        public virtual Proje Proje { get; set; }
    }
}
