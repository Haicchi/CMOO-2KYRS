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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        UserManager usermanager = new UserManager();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginUser(Object sender, EventArgs e)
        {
            string username = LoginUsername.Text;
            string password = LoginPassword.Text;
            usermanager.LoadUsersFromFileJson("users.json");
            if (usermanager.Users.ContainsKey(username))
            {
                if(usermanager.Users[username] == password)
                {
                    MessageBox.Show("Login succesfull");
                }
                else
                {
                    MessageBox.Show("Incorrect password");                }
                }
            else
            {
                MessageBox.Show("There is no such User go and register");
                return;
            }
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
            if (textBox.Text == "Type here")
            {
                textBox.Clear();
            }

        }
        private void FocusBack(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Type here";
            }
        }
    }
}
