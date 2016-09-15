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

namespace DynamicResourcesTest
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

        private void ChangeBrushProperty(object sender, RoutedEventArgs e)
        {
            SolidColorBrush brush = (SolidColorBrush)FindResource("winBrush");
            brush.Color = Colors.Blue;
        }
        private void ChangeBrush(object sender, RoutedEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush( Colors.Orange );
            Resources["winBrush"] = brush;
        }
        private void SetResourceProgrammatically(Object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.SetResourceReference(Button.BackgroundProperty, "winBrush");
        }
    }
}
