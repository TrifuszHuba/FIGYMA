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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Hasznaltember
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        private void pbPasswordCreate_PasswordChanged(object sender, RoutedEventArgs args)
        {
            tblPasswordCreate.Text = "";
            if (pbPasswordCreate.Password == "")
            {
                tblPasswordCreate.Text = "Jelszó";
            }
        }
        private void pbPasswordCreateRepeat_PasswordChanged(object sender, RoutedEventArgs args)
        {
            tblPasswordCreateRepeat.Text = "";
            if (pbPasswordCreateRepeat.Password == "")
            {
                tblPasswordCreateRepeat.Text = "Jelszó ismét";
            }
        }
        public CreateAccount()
        {
            InitializeComponent();
        }
        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            string data = "";
            string username;
            string email;
            string password;
            try
            {
                string text = File.ReadAllText(@$"Z:\_IKT\hasznaltember.hu\Hasznaltember\adatok\{tbUsernameCreate.Text}.txt");
                valid = false;
                lbNewUsernameError.Content = "Foglalt felhasználónév.";
            }
            catch (Exception a)
            {
                valid = true;
            }
            if (tbUsernameCreate.Text == "")
            {
                lbNewUsernameError.Content = "Helytelen felhasználónév";
                valid = false;
            }
            else if (valid)
            {
                username = $"{tbUsernameCreate.Text};";
                data += username;
            }
            if (!tbEmailCreate.Text.Contains("@"))
            {
                lbNewEmailError.Content = "Nem valós email";
                valid = false;
            }
            else if (valid)
            {
                email = $"{tbEmailCreate.Text};";
                data += email;
            }
            if (pbPasswordCreate.Password != pbPasswordCreateRepeat.Password || pbPasswordCreate.Password == "" || pbPasswordCreateRepeat.Password == "")
            {
                lbNewPasswordError.Content = "Jelszó nem egyezik, vagy nem helyes";
                valid = false;
            }
            else if (valid)
            {
                password = $"{pbPasswordCreate.Password};";
                data += password;
            }
            if (valid)
            {
                File.WriteAllText(@$"Z:\_IKT\hasznaltember.hu\Hasznaltember\adatok\{tbUsernameCreate.Text}.txt", data);
                MessageBox.Show("Sikeres regisztráció, vadászatra fel! grrr");
                Close();
            }
        }
    }
}
