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
    /// Interaction logic for WindowTask3.xaml
    /// </summary>
    public partial class WindowTask3 : Window
    {
        public WindowTask3()
        {
            InitializeComponent();
            Button1.Click += Button1_Click;
            Button2.Click += Button2_Click;
            Button3.Click += Button3_Click;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Text1.Text = "";
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Text1.Visibility = Visibility.Hidden;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Text1.Visibility = Visibility.Visible;
        }
    }
}
