using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace servisdemo13.BASE
{[DataContract]
[Serializable]

    public class StatusModel
    {
        [DataMember]
        [ConfigurationProperty("validateRequest", DefaultValue = false)]
            
        public Boolean? IsSuccess { get; set; }
    }
}