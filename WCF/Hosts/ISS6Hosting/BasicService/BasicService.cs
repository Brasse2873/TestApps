using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace BasicService
{
    [ServiceContract]
    public interface IBasicService
    {
        [OperationContract]
        int Method1( int arg );
    }

    public class BasicService : IBasicService
    {
        public int Method1(int arg)
        {
            return arg + 1;
        }
    }
}
