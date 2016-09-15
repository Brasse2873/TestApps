using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibraryHelloWorld;

namespace WinFormsClassLibraryHelloWorldClassClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClassLibraryHelloWorldClass helloWorlsClass = new ClassLibraryHelloWorldClass();

            label1.Text = helloWorlsClass.getHelloWorld();

        }
    }
}
