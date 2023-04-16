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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Schema;

namespace home_page
{
    /// <summary>
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Asd { get; set; }
        public ResetPassword()
        {
            InitializeComponent();
        }
        private void pbNewPassword_PasswordChanged(object sender, RoutedEventArgs args)
        {
            tblNewPassword.Text = "";
            if (pbNewPassword.Password == "")
            {
                tblNewPassword.Text = "Új jelszó";
            }
        }
        private void pbNewPasswordRepeat_PasswordChanged(object sender, RoutedEventArgs args)
        {
            tblNewPasswordRepeat.Text = "";
            if (pbNewPasswordRepeat.Password == "")
            {
                tblNewPasswordRepeat.Text = "Új jelszó ismét";
            }
        }
        private void btnResetPassword_Click(object sender, RoutedEventArgs e)
        {
            string[] rek1 = { "R", "K", "A", "E" };
            string[] rek2 = { "2", "0", "0", "3", "0", "7", "0", "7" };
            bool valid = true;
            try
            {
                string[] row = File.ReadAllLines(@$"Z:\_IKT\hasznaltember.hu\Hasznaltember\adatok\{tbUsername.Text}.txt");
                for (int i = 0; i < row.Length; i++)
                {
                    string[] data = row[i].Split(';');
                    Username = data[0];
                    Email = data[1];
                    string password = data[2];
                }
                lbUsernameError.Content = "";
                valid = true;
            }
            catch (Exception)
            {
                lbUsernameError.Content = "Nem regisztrált felhasználónév";
            }
            if (!tbEmail.Text.Contains("@"))
            {
                lbEmailError.Content = "Nem valós email";
                valid = false;
            }
            else if (tbEmail.Text != Email)
            {
                lbEmailError.Content = "Helytelen email";
                valid = false;
            }
            else
            {
                lbEmailError.Content = "";
                valid = true;
            }
            if (pbNewPassword.Password != pbNewPasswordRepeat.Password || pbNewPassword.Password == "")
            {
                valid = false;
                lbPasswordError.Content = "Nem jó jelszó formátum vagy nem egyező jelszavak";
            }
            else if (pbNewPassword.Password == pbNewPasswordRepeat.Password && pbNewPassword.Password != "")
            {
                lbPasswordError.Content = "";
                valid = true;

                string pw = pbNewPassword.Password;
                byte[] bytes = Encoding.UTF8.GetBytes(pw);
                string pass1 = Convert.ToHexString(bytes);

                Random random = new Random();
                int r1 = random.Next(0, 8);
                int r2 = random.Next(0, 4);
                string pass = $"{pass1}{rek2[r1]}{rek1[r2]}";

                Password = $"{pass}§n3_10pd_4_j31sz0t,_4_kurv4_4ny4d;";
            }
            if (valid)
            {
                string data = Username + ";" + Email + ";" + Password;
                File.WriteAllText(@$"Z:\_IKT\hasznaltember.hu\Hasznaltember\adatok\{tbUsername.Text}.txt", data);

                tbEmail.Text = "";
                tbUsername.Text = "";
                pbNewPassword.Password = "";
                pbNewPasswordRepeat.Password = "";
                lbTick.Content = "✔";

            }
        }
        private void Next1(object sender, RoutedEventArgs e)
        {
            pbNewPassword.Focus();
        }
        private void Next2(object sender, RoutedEventArgs e)
        {
            pbNewPasswordRepeat.Focus();
        }

        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
