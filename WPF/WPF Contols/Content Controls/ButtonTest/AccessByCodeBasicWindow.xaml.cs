using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ButtonTest
{
    /// <summary>
    /// Interaction logic for AccessByCodeBasicWindow.xaml
    /// </summary>
    public partial class AccessByCodeBasicWindow : Window
    {
        private Button button;

        public AccessByCodeBasicWindow()
        {
            InitializeComponent();

            CreateControl();
            ButtonProperties();
            ButtonEvents();
        }

        private void CreateControl()
        {
            button = new Button();
            Grid1.Children.Add(button);
        }

        private void ButtonProperties()
        {
            button.Content = "Button 1";
            button.IsCancel = true;
            button.IsDefault = true;
            Boolean isDef = button.IsDefaulted;
        }

        private void ButtonEvents()
        {
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked");
        }

    }
}
