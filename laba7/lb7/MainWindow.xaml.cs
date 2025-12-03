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

namespace lb7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public StudentViewModel viewModel = new StudentViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.LoadUsersFromFileJson("students.json");
            IfNoElements(this, new System.ComponentModel.CancelEventArgs());
        }

        public void IfNoElements(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(viewModel.Students.Count == 0)
            {
                MessageBox.Show("No elements in the list. Please add a student.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                NOELEM.Visibility = Visibility.Visible;
            }
        }
    }
}