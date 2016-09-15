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

namespace MediaElementTest
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

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.Stop();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            mediaElement2.Play();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            mediaElement2.Pause();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            mediaElement2.Stop();
        }

        private void mediaElement2_MediaOpened(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("MediaOpened");
        }

        private void mediaElement2_MediaEnded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("MediaEnded");
        }

        private void mediaElement3_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Failed to open media file. \nFile:" + mediaElement3.Source + "\nError: " + e.ErrorException.Message);
        }

    }
}
