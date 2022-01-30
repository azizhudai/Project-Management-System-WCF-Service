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
    public class InsertTaskModel
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int ProjectId { get; set; }
        [DataMember]
        public string TaskName { get; set; }
        [DataMember]
        public string TaskDetail { get; set; }
        [DataMember]
        public string TaskStartDate { get; set; }
        [DataMember]
        public string TaskEndDate { get; set; }
    }
}