using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lb7
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            Loaded += AddWindow_Loaded;

        }
        private void AddWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataToUI();
        }
        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Zа-яА-Я\\s]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void OnAnyControlClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Input.CommandManager.InvalidateRequerySuggested();
        }
        private void LoadDataToUI()
        {
            if (this.DataContext is Student student)
            {
                switch (student.sex)
                {
                    case "Male": Male.IsChecked = true; break;
                    case "Female": Female.IsChecked = true; break;
                }
               
            }
        }
    }
}
