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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hasznaltember
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Majom");
        }

        private void btnforgotPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Majom:");
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(pbPassword.Password);
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
