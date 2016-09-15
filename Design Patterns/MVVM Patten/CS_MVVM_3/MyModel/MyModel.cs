using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MyModel
{

    //Todo: (1) Create an empty model. In this case the MyModel class 
    //Todo: (8b) Add interface INotifyPropertyChanged if module sends events
    public class MyModel : INotifyPropertyChanged
    {
        private string _modelData;

        //Todo: (5) Model, Add properties
        public string ModelData
        { 
            get{ return _modelData; } 
            set{ _modelData = value; } 
        }

        #region Methods
        //Todo: (9) Model, Add methods
        public void DoModuleAction()
        {
            _modelData = _modelData.ToUpper();
            if( PropertyChanged != null )
                PropertyChanged(this, new PropertyChangedEventArgs("ModelData")); //Todo: (13) Property changed. Send event to inform view
        }

        public bool IsValid() { return _modelData.Length>0?true:false; }
        #endregion

        #region INotifyPropertyChange //Todo:(8b)
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
