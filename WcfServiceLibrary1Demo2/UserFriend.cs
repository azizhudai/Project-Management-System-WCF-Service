namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserFriend")]
    public partial class UserFriend
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int UserJobFriendId { get; set; }

        public bool Aktive { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Kullanici Kullanici1 { get; set; }
    }
}
