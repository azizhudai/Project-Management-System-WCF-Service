namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DokumanGorev")]
    public partial class DokumanGorev
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Turu { get; set; }

        public int? GorevId { get; set; }

        public byte[] GorevDokumanlar { get; set; }

        public virtual Gorev Gorev { get; set; }
    }
}
