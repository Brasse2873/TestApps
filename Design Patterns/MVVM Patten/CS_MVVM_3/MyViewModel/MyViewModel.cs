using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; //Todo: (8)

using System.Windows.Input;

using MyModel; //Todo: (2)

namespace MyViewModel
{
    //Todo: (2) Create an empty view model, Add ref to the model
    //Todo: (8) Add interface INotifyPropertyChanged
    public class MyViewModel : INotifyPropertyChanged
    {

        private MyModel.MyModel _model = new MyModel.MyModel(); //Todo: (3) Create the model and keep it as private field.
        private ButtonCommand _btnCmd; //Todo: (11) Create Command obj, keep it private

        public MyViewModel()
        {
            _btnCmd = new ButtonCommand(_model.DoModuleAction, _model.IsValid); //Todo: (11)
            _model.PropertyChanged+=_model_PropertyChanged; //Todo: (14) Subscribe to module propery changed events
        }

        #region Properties exposed to the view

        public string txtModelData //Todo: (6) ViewModel Create Properties for model properties, Use GUI naming convention
        {
            get { return _model.ModelData; }
            set { _model.ModelData = value; }
        }

        public ICommand BtnCmd { get { return _btnCmd; } } //Todo: (12) Create property that button in View can bind to
        #endregion

        #region Events
        public void _model_PropertyChanged(object sender, PropertyChangedEventArgs e) //Todo: (14)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("txt" +e.PropertyName));  //Todo:(15) Post event to the View
        }
        #endregion

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged; //Todo: (8)
        #endregion
    }

    //Todo: (10) ViewModel, Create ICommand class to handle calls commands from view to viewmodel
    public class ButtonCommand : ICommand
    {
        private Action _executeMethod;
        private Func<bool> _validateMethod;

        public ButtonCommand(Action executeMethod, Func<bool> validateMethod)
        {
            _executeMethod = executeMethod;
            _validateMethod = validateMethod;
        }

        #region ICommand implementation
        public bool CanExecute(object par) 
        {
            return _validateMethod(); 
        }

        public void Execute(object par)
        {
            _executeMethod();
        }

        public event EventHandler CanExecuteChanged;
        #endregion
    }
}
