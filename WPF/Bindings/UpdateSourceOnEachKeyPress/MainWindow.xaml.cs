using System.ComponentModel;
using System.Windows;

namespace UpdateSourceOnEachKeyPress
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        private string src = "MySource";
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Src
        {
            get
            {
                return src;
            }

            set
            {
                src = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Src"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
