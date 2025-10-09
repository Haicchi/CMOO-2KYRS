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
    /// Interaction logic for WindowTask4.xaml
    /// </summary>
    public partial class WindowTask4 : Window
    {
        public WindowTask4()
        {
            InitializeComponent();
            Button1.Click += Button1_Click;
            Button2.Click += Button1_Click;
            Button3.Click += Button1_Click;
            Button4.Click += Button1_Click;
            Button5.Click += Button1_Click;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            clickedButton.Visibility = Visibility.Collapsed;
            string buttonName = clickedButton.Name;
            switch (buttonName)
            {
                case "Button1":
                    Button2.Visibility = Visibility.Collapsed;
                    break;
                case "Button2":
                    Button4.Visibility = Visibility.Collapsed;
                    break;
                case "Button3":
                    Button1.Visibility = Visibility.Collapsed;
                    break;
                case "Button4":
                    Button3.Visibility = Visibility.Collapsed;
                    break;
                case "Button5":
                    Button5.Visibility = Visibility.Collapsed;
                    break;

            }
            Button[] buttons = { Button1, Button2, Button3, Button4, Button5 };
            int calc = 0;
            foreach (var button in buttons)
            {
                if (button.Visibility == Visibility.Collapsed)
                {
                    calc++;
                }
            }
            if (calc == 5)
            {
                MessageBox.Show("You Win!");
            }
        }
    }
}
