using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyModel;

namespace MyViewModel
{
    public class MyViewModel
    {
        private MyModel.MyModel _model = new MyModel.MyModel();

        public string txtStrProp 
        { 
            get{ return _model.StrProp; }
            set{ _model.StrProp = value; }
        }

        public string txtIntProp
        {
            get { return _model.IntProp.ToString(); }
            set { _model.IntProp = Convert.ToInt32(value); }
        }
    }
}
