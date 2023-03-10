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
using static System.Net.Mime.MediaTypeNames;

namespace Hasznaltember
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }
        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            
            
            if(true/*nincs regisztrálva ilyen név(kell hozzá a kopasz)*/)
            {
                string username = tbUsernameCreate.Text;
            }
            else if (true/*van regisztrálva ilyen név(kell hozzá a kopasz)*/)
            {
                MessageBox.Show("Foglalt felhasználónév te Majom");
            }
            if (tbEmailCreate.Text.Contains("@")/*&& nincs regisztrálva ilyen email(kell hozzá a kopasz)*/)
            {
                string email = tbEmailCreate.Text;
            }
            else if (!tbEmailCreate.Text.Contains("@")/*|| nincs regisztrálva ilyen email(kell hozzá a kopasz)*/)
            {
                MessageBox.Show("Nem valós email te Majom");
            }
            if(tbPasswordCreate.Text == tbPasswordCreateRepeat.Text)
            {
                string password = tbPasswordCreate.Text;
            }
            else if(tbPasswordCreate.Text != tbPasswordCreateRepeat.Text)
            {
                MessageBox.Show("Jelszó nem egyezik te Majom");
            }
        }
    }
}
