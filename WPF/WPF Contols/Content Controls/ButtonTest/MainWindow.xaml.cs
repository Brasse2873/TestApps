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

namespace ButtonTest
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

        private void ShowWin(Window win)
        {
            win.Title =  win.GetType().ToString();
            win.Width = 500;
            win.Owner = this;
            win.Show();
        }

        private void mnuProperties_Click_1(object sender, RoutedEventArgs e)
        {
            ShowWin(new PropertiesWindow());
        }

        private void mnuAccessByCodeBasic_Click_1(object sender, RoutedEventArgs e)
        {
            ShowWin(new AccessByCodeBasicWindow());
        }

        private void mnuAccessByCodeMethods_Click_1(object sender, RoutedEventArgs e)
        {
            ShowWin(new AccessByCodeMethodsWindow ());
        }

        private void mnuEvents_Click_1(object sender, RoutedEventArgs e)
        {
            ShowWin(new EventsWindow());
        }
    }
}
