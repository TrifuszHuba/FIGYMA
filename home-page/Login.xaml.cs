﻿using System;
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

namespace home_page
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Pass { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool valid = false;
            try
            {
                string[] row = File.ReadAllLines($"{tbUsername.Text}.txt");
                for (int i = 0; i < row.Length; i++)
                {
                    string[] data = row[i].Split(';');
                    Username = data[0];
                    Email = data[1];
                    Pass = data[2];
                }
                lbUsernameError.Content = "";
                lbPasswordError.Content = "";
                valid = true;
            }
            catch (Exception)
            {
                lbUsernameError.Content = "Hibás felhasználónév";
                valid = false;
            }
            if (valid)
            {
                string[] password = Pass.Split("§");
                string pass1 = password[0].Remove(password[0].Length - 1);
                string pass = pass1.Remove(pass1.Length - 1);

                string pw = pbPassword.Password;
                byte[] bytes = Encoding.UTF8.GetBytes(pw);
                string pass2 = Convert.ToHexString(bytes);

                if (pass == pass2)
                {
                    MainWindow mainWin = new MainWindow();
                    mainWin.Show();
                    this.Close();
                }
                else
                {
                    lbPasswordError.Content = "Hibás jelszó";
                }
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
            if (pbPassword.Password == "")
            {
                tblPassword.Text = "jelszó";
            }
        }
        private void Next(object sender, RoutedEventArgs e)
        {
            pbPassword.Focus();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
