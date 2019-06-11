using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Text;

namespace BMS.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBMSService" in both code and config file together.
    [ServiceContract]
    public interface IBMSService
    {
        [OperationContract]
        Bierkroegen DoWork();
    }
}
