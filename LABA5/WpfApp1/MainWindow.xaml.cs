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

namespace WpfApp1
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserManager userManager = new UserManager();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginForm(object sender, EventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
        
        private void RegisterUser(object sender, EventArgs e)
        {
            userManager.LoadUsersFromFileJson("users.json");

            string username = UsernameBox.Text;
            string password = PasswordBox.Text;
            string email = EmailBox.Text;
            string passconfirm = PasswordConfirm.Text;

            if (password != passconfirm)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }
            if (userManager.Users.ContainsKey(username))
            {
                MessageBox.Show("Username already exists!");
                return;
            }

            User user = new User(username, password, email);
            userManager.AddUser(user);
            userManager.SaveUsersToFileJson("users.json");

            MessageBox.Show("User registered successfully!");
        }
        private void SocialMediaClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Name == "Facebook")
            {
                FacebookLoginPage facebookLoginPage = new FacebookLoginPage();
                facebookLoginPage.Show();

            }
            else if (button.Name == "Google")
            {
                GoogleLoginPage googleLoginPage = new GoogleLoginPage();
                googleLoginPage.Show();
            }
            else if (button.Name == "Twitter")
            {
                TwitterLoginPage twitterLoginPage = new TwitterLoginPage();
                twitterLoginPage.Show();
            }
        }
        private void FocusClear(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if(textBox.Text == "Type here")
            {
                textBox.Clear();
            }
            
        }
        private void FocusBack(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if(string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Type here";
            }
        }

    }
}