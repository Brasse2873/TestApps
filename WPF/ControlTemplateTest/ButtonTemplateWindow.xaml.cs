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

namespace ControlTemplateTest
{
    /// <summary>
    /// Interaction logic for ButtonTemplateWindow.xaml
    /// </summary>
    public partial class ButtonTemplateWindow : Window
    {
        public ButtonTemplateWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked");
        }
    }
}
