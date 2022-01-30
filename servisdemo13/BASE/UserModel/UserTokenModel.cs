using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace servisdemo13.BASE.UserModel
{
    [Serializable]
    [DataContract]
    public class UserTokenModel
    {
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string TokenId { get; set; }
    }
}