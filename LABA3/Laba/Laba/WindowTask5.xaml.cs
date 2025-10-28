using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for WindowTask5.xaml
    /// </summary>
    public partial class WindowTask5 : Window
    {
        public WindowTask5()
        {
            InitializeComponent();
            Button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
           double perevod = 2.20462;
           string input = TextBox1.Text;
           double pounds = 0;
            if (double.TryParse(input.Replace(',','.'), CultureInfo.InvariantCulture, out pounds))
            {
                if (pounds < 0)
                {
                    MessageBox.Show("wrong input");
                    return;
                }
                double kilograms = pounds / perevod;
                Label1.Content = kilograms.ToString();
            }
            else
            {
                MessageBox.Show("wrong input");
            }
        }
    }
}
