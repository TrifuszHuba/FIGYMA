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

namespace home_page
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            personDataWrite();
        }
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            // a cséndzsid nem volt jó, hát ez lesz
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            // itt kéne a comboboxból leszopkodnia és elküldenie az AI-nak a jellemzőket
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            mainPicture.Source = image.Source;
            image.Source = mainPicture.Source;
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void personDataWrite()
        {
            personData.Text = "On April 1st 1924 I've began to serve my sentence of imprisonment in the fortress of Landsberg am Lech, following the judgment of the Munich People's Court of that time. After years of uninterrupted labour, it was now possible for the first time to begin a work which has many had asked for, and I myself thought would be beneficial for the movement. So I decided to dedicate two volumes, not only for the movement, but also its development. \n Eddig tudom fejből XD";
        }

        private void NObutton_Click(object sender, RoutedEventArgs e)
        {
            // fuj
        }

        private void YESbutton_Click(object sender, RoutedEventArgs e)
        {
            // Weöres Sándor: Baszás, szex, kúrás
        }
    }
}
