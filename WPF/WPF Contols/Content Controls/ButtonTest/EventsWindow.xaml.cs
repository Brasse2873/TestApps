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
    /// Interaction logic for EventsWindow.xaml
    /// </summary>
    public partial class EventsWindow : Window
    {
        public EventsWindow()
        {
            InitializeComponent();
        }

        private void ClearEventView_Click_1(object sender, RoutedEventArgs e)
        {
            OutputEvents.Inlines.Clear();
        }

        private void Button_Event( object sender, RoutedEventArgs e)
        {
            OutputEvents.Inlines.Add(new Run(sender.ToString() + ": " + e.RoutedEvent.Name + "\n"));
        }
    }
}
