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

namespace CS_MVVM_3
{
    /// <summary>
    /// Interaction logic for MyView.xaml
    /// </summary>
    /// 

    //Todo: (4) Create an empty View. No code (code behind) should be written in the View. Bind code in XAML


    //Todo: (7) View, Import and create ModelView object. Bind properties in .XAML file
    /*
     *  XAML code 
        xmlns:custns="clr-namespace:CustomerViewModel;assembly=CustomerViewModel" 
        <Window.Resources>
            <custns:CustomerViewModel x:Key="custviewobj" TxtCustomerName="Shiv" TxtAmount="1000" IsMarried=”true”/>
     *  <Label x:Name="lblName"  Content="{Binding TxtCustomerName, Source={StaticResourcecustviewobj}}"/>
     */

    //Todo: (13) Bind Button.Command to ViewModel ICommand property
    //Command="{Binding BtnCmd, Mode=OneWay, Source={StaticResource vm}}"
    public partial class MyView : Window
    {
        public MyView()
        {
            InitializeComponent();
        }
    }
}
