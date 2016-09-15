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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BublingEventTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            txtEvents.Text += "TextBox ";
            e.Handled = (bool)optHandleInTextBox.IsChecked;
        }

        private void StackPanel_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            txtEvents.Text += "StackPanel ";
            e.Handled = (bool)optHandleInStackFrame.IsChecked;
        }

        private void Window_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            txtEvents.Text += "Windows ";
            e.Handled = (bool)optHandleInWindows.IsChecked;
        }

        private void Window_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            txtEvents.Text = "";
        }
    }
}
