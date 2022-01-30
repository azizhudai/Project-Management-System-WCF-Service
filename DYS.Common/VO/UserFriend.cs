using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYS.Common.VO
{
    public class UserFriend : BaseEntity
    {
        [Key]
        public int Id { get; set; }

       // [ForeignKey("Kullanici")]
        public int UserId{ get; set; }

       // [ForeignKey("Kullanici")]
        public int UserJobFriendId { get; set; }
        public bool Aktive { get; set; }

        public virtual Kullanici Kullanici1 { get; set; }

        public virtual Kullanici Kullanici2 { get; set; }



    }
}
