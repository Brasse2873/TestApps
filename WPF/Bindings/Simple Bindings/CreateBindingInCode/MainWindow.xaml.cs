using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Controls;

namespace CreateBindingInCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged //Todo 4a: Derive from INotifyPropertyChanged for source change events
    {
        private string textBoxDataSource = "My Text";

        public string TextBoxDataSource
        {
            get { return textBoxDataSource; }
            set 
            { 
                textBoxDataSource = value; 
                if( PropertyChanged != null )
                    PropertyChanged(this,new PropertyChangedEventArgs("TextBoxDataSource")); //Todo 4c: Send event
            }
        }

        public MainWindow() 
        {
            InitializeComponent();

            //Do this AFTER InitializeComponent
            Binding binding = new Binding("TextBoxDataSource");     //Todo 1: Create a new binding object. Initialize it to a PUBLIC property
            binding.Source = this;                                  //Todo 2: Set current window as source
            myTextBox.SetBinding(TextBox.TextProperty, binding);    //Todo 3: Bind property of UI element to the new binding instance

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBoxDataSource = "My Text updated by button";
        }

        public event PropertyChangedEventHandler PropertyChanged; //Todo 4b: Implement INotifyPropertyChanged interface
    }
}
