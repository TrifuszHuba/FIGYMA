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

namespace Hasznaltember
{
    /// <summary>
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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
                valid = true;
            }
            catch (Exception a)
            {
                lbUsernameError.Content = "Nem regisztrált felhasználónév";
            }
            if (!tbEmail.Text.Contains("@"))
            {
                lbEmailError.Content = "Nem valós email";
                valid = false;
            }
            else if(tbEmail.Text != Email)
            {
                lbEmailError.Content = "Helytelen email";
                valid = false;
            }
            if(pbNewPassword.Password != pbNewPasswordRepeat.Password || pbNewPassword.Password == "")
            {
                valid = false;
                lbPasswordError.Content = "Nem jó jelszó formátum vagy nem egyező jelszavak";
            }
            else if(pbNewPassword.Password == pbNewPasswordRepeat.Password && pbNewPassword.Password != "")
            {
                Password = pbNewPassword.Password;
            }
            if (valid)
            {
                string data = Username + ";" + Email + ";" + Password;
                File.WriteAllText(@$"Z:\_IKT\hasznaltember.hu\Hasznaltember\adatok\{tbUsername.Text}.txt", data);
                MessageBox.Show("Az új jelszó sikeresen beálltva.");
                Close();
            }
        }
    }
}
