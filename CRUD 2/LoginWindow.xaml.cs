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

namespace CRUD_2
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            // Here you would typically check the username and password against a database or other data store
            // For this example, we'll just check against a hardcoded username and password
            if (username == "user" && password == "password")
            {
                MessageBox.Show("Login successful!");
                // Navigate to the next window or perform other actions upon successful login
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                // Close the login window
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed. Please try again.");
            }
        }
    }
}
