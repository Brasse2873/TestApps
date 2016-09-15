using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.Runtime.Serialization;


namespace BasicService
{
    [ServiceContract]
    public interface IBasicService
    {
        [OperationContract]
        int Method( int arg );
    }

}
