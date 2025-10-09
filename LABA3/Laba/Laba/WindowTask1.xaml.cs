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

namespace Laba
{
    /// <summary>
    /// Interaction logic for WindowTask1.xaml
    /// </summary>
    public partial class WindowTask1 : Window
    {
        public WindowTask1()
        {
            InitializeComponent();
            Button1.Click += Button1_Click;
            Button2.Click += Button1_Click;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button clickedbutton = (Button)sender;
            Label1.Content = clickedbutton.Content;
        }
    }
}
