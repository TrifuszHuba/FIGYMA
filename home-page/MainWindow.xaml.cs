using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        //private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        //{
            
        //}
        string modelPickerRGBColor = "";
        private void picker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // RGB kódban kéne visszaadnia a kiválasztott színt
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();

            if (cbType.SelectedItem.ToString() != "Típus")
            {
                if (chbMale.IsChecked == true && chbFemale.IsChecked == false)
                {
                    data.Add("male");
                }
                else if (chbMale.IsChecked == false && chbFemale.IsChecked == true)
                {
                    data.Add("female");
                }
                else
                {
                    data.Add("any XD");
                }
            }
            if (cbCondition.SelectedItem.ToString() != "Állapot")
            {
                data.Add(cbType.SelectedItem.ToString());
            }
            if (cbWeight.SelectedItem.ToString() != "Tömeg")
            {
                data.Add(cbType.SelectedItem.ToString());
            }
            if (cbHeight.SelectedItem.ToString() != "Kivitel")
            {
                data.Add(cbType.SelectedItem.ToString());
            }
            if (cbType.SelectedItem.ToString() != "Modell")
            {
                //data.Add(picker.);
            }
            if (cbType.SelectedItem.ToString() != "Ajtók száma")
            {
                data.Add(tbDoors.Text.ToString());
            }
            if (yearFrom.Text != null && yearTo.Text != null)
            {
                data.Add($"from {yearFrom.Text} to {yearTo.Text}");
            }
            if (cbType.SelectedItem.ToString() != "Típus")
            {
                data.Add(cbType.SelectedItem.ToString());
            }
            if (cbType.SelectedItem.ToString() != "Típus")
            {
                data.Add(cbType.SelectedItem.ToString());
            }
            if (cbType.SelectedItem.ToString() != "Típus")
            {
                data.Add(cbType.SelectedItem.ToString());
            }

            //File.WriteAllText("personData.txt", data);
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            mainPicture.Source = image.Source;
            image.Source = mainPicture.Source;
        }
        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            int doorsNum = int.Parse(tbDoors.Text);

            if (doorsNum > -1)
            {
                doorsNum--;
                tbDoors.Text = doorsNum.ToString();
            }
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            int doorsNum = int.Parse(tbDoors.Text);

            if (doorsNum < 5 && chbMale.IsChecked == true)
            {
                doorsNum++;
                tbDoors.Text = doorsNum.ToString();
            }
            else if (doorsNum < 4)
            {
                doorsNum++;
                tbDoors.Text = doorsNum.ToString();
            }
        }


        // options: alap: Típus
        //  kiválasztott: Típus: Férfi

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
