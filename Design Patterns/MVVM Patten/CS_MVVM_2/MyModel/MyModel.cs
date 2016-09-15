using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModel
{
    public class MyModel
    {
        
        public string StrProp { get; set; }
        public int IntProp { get; set; }
        public string concatStrPropIntProp { get; private set;}

        //todo: (1) Create action in the model
        public void DoAction()
        {
            concatStrPropIntProp = StrProp + IntProp.ToString();
        }
    }
}
