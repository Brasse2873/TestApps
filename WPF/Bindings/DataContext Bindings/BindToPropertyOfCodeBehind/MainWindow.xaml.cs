using System.ComponentModel;
using System.Windows;

namespace BindToPropertyOfCodeBehind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window ,INotifyPropertyChanged
    {
        private string myString = "MyString value";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string MyString
        {
            get { return myString; }
            set 
            { 
                myString = value; 
                if( PropertyChanged != null )
                    PropertyChanged(this,new PropertyChangedEventArgs("MyString"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyString = "Changed by button";
        }
    }
}
