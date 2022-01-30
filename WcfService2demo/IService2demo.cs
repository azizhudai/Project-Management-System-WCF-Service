using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService2demo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2demo" in both code and config file together.
    [ServiceContract]
    public interface IService2demo
    {
        [OperationContract]
        void DoWork();
    }
}
