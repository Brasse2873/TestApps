using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GridTest
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ColumnDefinitionWindow win = new ColumnDefinitionWindow();
            win.Owner = this;
            win.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            RowDefinitionWindow win = new RowDefinitionWindow();
            win.Owner = this;
            win.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            GridSplitterWindow win = new GridSplitterWindow();
            win.Owner = this;
            win.Show();
        }

        private void button0_Click_1(object sender, RoutedEventArgs e)
        {
            Basic win = new Basic();
            win.Owner = this;
            win.Show();
        }

        private void button4_Click_1(object sender, RoutedEventArgs e)
        {
            SizeByContentWindow win = new SizeByContentWindow();
            win.Owner = this;
            win.Show();
        }
    }
}
