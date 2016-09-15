using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace BasicServiceWith2MEXTech
{
    [ServiceContract]
    interface IBasicService2MexTech
    {
        [OperationContract]
        int Method1( int arg );
    }
}
