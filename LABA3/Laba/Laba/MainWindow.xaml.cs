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

namespace Laba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button1.Click += Button1_Click;
            Button2.Click += Button2_Click;
            Button3.Click += Button3_Click;
            Button4.Click += Button4_Click;
            Button5.Click += Button5_Click;
            Button6.Click += Button6_Click;
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            WindowTask6 windowTask6 = new WindowTask6();
            windowTask6.Show();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            WindowTask5 windowTask5 = new WindowTask5();
            windowTask5.Show();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            WindowTask4 windowTask = new WindowTask4();
            windowTask.Show();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            WindowTask3 windowTask3 = new WindowTask3();
            windowTask3.Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            WindowTask2 windowTask2= new WindowTask2();
            windowTask2.Show();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            WindowTask1 windowTask1 = new WindowTask1();
            windowTask1.Show();
        }
    }
}