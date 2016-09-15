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

namespace MediaPlayerTest
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

        private System.Windows.Media.MediaPlayer player = new MediaPlayer();

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            player.Open( new Uri("E:\\Utveckling Testprogram\\C#\\MediaPlayerTest\\0006. The Eagles - Hotel California.mp3") );            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            player.Play();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }


    }
}
