using System;
using System.Windows;
using System.Windows.Controls;


namespace ConsoleApplication1
{
    class Program
    {
        [STAThread] //Single threaded appartment required by WPF

        static void Main(string[] args)
        {

            Button b = new Button(); //Create a WPF Button
            b.Content = "Hej hopp";

            Window w = new Window(); //Create a WPF Window
            w.Title = "Min app";
            w.Content = b;

            Application app = new Application();

            app.Run(w); //Run the application
        }
    }
}
