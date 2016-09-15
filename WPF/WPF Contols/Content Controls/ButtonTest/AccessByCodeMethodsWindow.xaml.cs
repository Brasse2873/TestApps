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
    /// Interaction logic for AccessByCodeMethodsWindow.xaml
    /// </summary>
    public partial class AccessByCodeMethodsWindow : Window
    {
        private Button button;

        public AccessByCodeMethodsWindow()
        {
            InitializeComponent();

            CreateButton();

            AddButtonToParent();

            AddButtonEvents();
        }

        private void CreateButton()
        {
            button = new Button();
            button.Content = "Button";
        }

        private void AddButtonToParent()
        {
            AddChild(button); 
        }

        private void AddButtonEvents()
        {
            button.Click += Button_events;
        }

        private void ButtonMethods()
        {
        }

        private void Button_events(object sender, RoutedEventArgs e)
        {
            ButtonMethods();
            e.Handled = true;
        }

    }
}
