using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hasznaltember
{
    public partial class MainWindow : Window
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Asd { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Password = null;
            Email = null;
            Username = null;
            Asd = null;
            try
            {
                string[] row = File.ReadAllLines(@$"Z:\_IKT\hasznaltember.hu\Hasznaltember\adatok\{tbUsername.Text}.txt");
                for (int i = 0; i < row.Length; i++)
                {
                    string[] data = row[i].Split(';');
                    Username = data[0];
                    Email = data[1];
                    Asd = data[2];
                }
                lbUsernameError.Content = "";
                lbPasswordError.Content = "";
            }
            catch (Exception a)
            {
                lbUsernameError.Content = "Hibás felhasználónév";
            }
            string[] password = Asd.Split("§");
            Password = password[0];
            if (pbPassword.Password == Password)
            {
                MessageBox.Show("Bejelentkeztél te Majom");
            }
            else
            {
                lbPasswordError.Content = "Hibás jelszó";
            }
        }

        private void btnforgotPassword_Click(object sender, RoutedEventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Show();
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.Show();
            
        }

        private void PasswordChangedHandler(object sender, RoutedEventArgs args)
        {
            tblPassword.Text = "";
            if(pbPassword.Password == "")
            {
                tblPassword.Text = "password";
            }
        }
    }
}
