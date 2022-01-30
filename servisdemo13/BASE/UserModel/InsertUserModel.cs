using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace servisdemo13.BASE.UserModel
{
    [Serializable]
    [DataContract]
    public class InsertUserModel
    {
        [DataMember]
        public string UserMail { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserSurname { get; set; }
        [DataMember]
        public string Password { get; set; }

    }
}