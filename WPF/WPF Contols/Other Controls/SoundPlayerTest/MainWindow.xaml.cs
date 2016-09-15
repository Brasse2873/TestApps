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

namespace SoundPlayerTest
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

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            player.SoundLocation = "..\\..\\one.wav";
            player.Load();
            player.Play();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }
    }
}
