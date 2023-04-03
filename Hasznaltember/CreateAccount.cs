using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
            string lowercase = pbPasswordCreate.Password.ToLower();
            string[] specialChar = {"@","&","#","<",">","{","}","?",",",";",".","-","*","_","|","$","[","]","'","+","~","ˇ","^","!","˘","%","°","/","˛","=","`","(",")","˙","´","˝","¨","¸"};
            string[] rek1 = { "R", "K", "A", "E"};
            string[] rek2 = { "2", "0", "0", "3", "0", "7", "0", "7" };
            bool contains = false;
            foreach (string a in specialChar)
            {
                if (pbPasswordCreate.Password.Contains(a))
                {
                    contains = true;
                }
            }
            try
            {
                string text = File.ReadAllText(@$"Z:\_IKT\hasznaltember.hu\Hasznaltember\adatok\{tbUsernameCreate.Text}.txt");
                valid = false;
                lbNewUsernameError.Content = "Foglalt felhasználónév";
            }
            catch (Exception a)
            {
                lbNewUsernameError.Content = "";
                valid = true;
            }
            if (tbUsernameCreate.Text == "")
            {
                lbNewUsernameError.Content = "Helytelen felhasználónév";
                valid = false;
            }
            else if (valid)
            {
                lbNewUsernameError.Content = "";
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
                lbNewEmailError.Content = "";
                email = $"{tbEmailCreate.Text};";
                data += email;
            }
            if (pbPasswordCreate.Password != pbPasswordCreateRepeat.Password || pbPasswordCreate.Password == "" || pbPasswordCreateRepeat.Password == "")
            {
                lbNewPasswordError.Content = "Jelszó nem egyezik, vagy nem helyes";
                valid = false;
            }
            else if (pbPasswordCreate.Password == lowercase || !contains)
            {
                lbNewPasswordError.Content = "";
                valid = false;
                lbNewPasswordError.Content = "A jelszónak tartalmaznia kell legalább egy nagyvetűt és egy különleges karaktert";
            }
            if (valid)
            {
                string pw = pbPasswordCreate.Password;
                byte[] bytes = Encoding.UTF8.GetBytes(pw);
                string pass1 = Convert.ToHexString(bytes);

                Random random = new Random();
                int r1 = random.Next(0, 8);
                int r2 = random.Next(0, 4);
                string pass = $"{pass1}{rek2[r1]}{rek1[r2]}";

                password = $"{pass}§n3_10pd_4_j31sz0t,_4_kurv4_4ny4d;";
                data += password;

                File.WriteAllText(@$"Z:\_IKT\hasznaltember.hu\Hasznaltember\adatok\{tbUsernameCreate.Text}.txt", data);

                tbEmailCreate.Text = "";
                tbUsernameCreate.Text = "";
                pbPasswordCreate.Password = "";
                pbPasswordCreateRepeat.Password = "";
                lbTick.Content = "✔";
            }
        }
        private void Next1(object sender, RoutedEventArgs e)
        {
            pbPasswordCreate.Focus();
        }
        private void Next2(object sender, RoutedEventArgs e)
        {
            pbPasswordCreateRepeat.Focus();
        }

        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
