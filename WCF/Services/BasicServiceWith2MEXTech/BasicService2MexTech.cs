using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicServiceWith2MEXTech
{
    public class BasicService2MexTech : IBasicService2MexTech
    {
        #region IBasicService2MexTech members
        public int Method1( int arg )
        {
            return arg + 1;
        }
        #endregion
    }
}
