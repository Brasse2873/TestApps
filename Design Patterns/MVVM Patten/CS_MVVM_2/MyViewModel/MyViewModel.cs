using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input; //For ICommand
using System.ComponentModel; //For INotifyPropertyChanged

using MyModel;

namespace MyViewModel
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private MyModel.MyModel _model = new MyModel.MyModel();
        private ButtonCommand _buttonCmd;

        public MyViewModel() 
        {
            _buttonCmd = new ButtonCommand(this);
        }

        public string txtStrProp { 
            get { return _model.StrProp; } 
            set {_model.StrProp = value; } 
        }

        public string txtIntProp
        {
            get { return _model.IntProp.ToString(); }
            set { _model.IntProp = Convert.ToInt32(value); }
        }

        public string lblConcatStrPropIntProp 
        {
            get { return _model.concatStrPropIntProp; }
        }

        public ICommand onDoAction{ get{return _buttonCmd;} }

        public void DoAction() { 
            _model.DoAction(); 
            if( PropertyChanged != null )
                PropertyChanged(this, new PropertyChangedEventArgs("lblConcatStrPropIntProp"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class ButtonCommand : ICommand 
    {
        private MyViewModel _viewModel;
        public ButtonCommand( MyViewModel viewModel ) 
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _viewModel.DoAction();
        }
    }
}
