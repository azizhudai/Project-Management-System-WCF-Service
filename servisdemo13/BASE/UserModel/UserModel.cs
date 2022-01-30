using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace servisdemo13.BASE.UserModel
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public int UserId { get; set; }

    }
}