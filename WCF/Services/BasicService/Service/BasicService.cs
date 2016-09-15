using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BasicService
{
    public class BasicService : IBasicService
    {
        #region IBasicService members
        public int Method(int arg)
        {
            return arg + 1;
        }
        #endregion
    }
}
