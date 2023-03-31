using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            personDataWrite();
        }
        
        private void btnDropdown_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            StackPanel parent = (StackPanel)b.Parent;
            if (parent.Children[1].Visibility != Visibility.Visible)
            {
                for (int i = 1; i < parent.Children.Count; i++)
                {
                    parent.Children[i].Visibility = Visibility.Visible;
                }
            }
            else
            {
                for (int i = 1; i < parent.Children.Count; i++)
                {
                    parent.Children[i].Visibility = Visibility.Collapsed;
                }
            }
        }

        int weight;
        private void buttonWeight_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b.Content.ToString() != "Caterpillar 795F AC")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(b.Content);
                sb.Remove(sb.Length - 2, 2);
                string weightrange = sb.ToString();
                string[] w = weightrange.Split("-");
                int weight1 = int.Parse(w[0]);
                int weight2 = int.Parse(w[1]);
                weight = (weight1 + weight2) / 2;
            }
            //else
            //{
                
            //}
        }

        int minHeight = 0;
        private void tbMinHeight_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            minHeight = int.Parse(t.Text);

            if (minHeight != 0 && maxHeight != 0)
            {
                Height();
                bmi();
            }
        }
        int maxHeight = 0;
        private void tbMaxHeight_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            maxHeight = int.Parse(t.Text);

            if (minHeight != 0 && maxHeight != 0)
            {
                Height();
                bmi();
            }

        }

        string heightForAI = "";
        int height = 0;
        private void Height()
        { 
            if (minHeight > 170 && maxHeight > 180)
            {
                heightForAI = "tall";
            }
            else if (minHeight > 130 && maxHeight< 170) 
            {
                heightForAI = "average height";
            }
            else if (minHeight > 70 && maxHeight < 160)
            {
                heightForAI = "short";
            }

            height = (minHeight + maxHeight) / 2;
        }
        string bodyTypeFromBMI = "";
        private void bmi()
        {
            double bmi = weight / ((height/100.0) * (height / 100.0));
            if (bmi < 18.5)
            {
                bodyTypeFromBMI = "skinny";
            }
            else if (bmi < 25)
            {
                bodyTypeFromBMI = "normal weight";
            }
            else if (bmi < 30)
            {
                bodyTypeFromBMI = "overweight";
            }
            else if (bmi < 35)
            {
                bodyTypeFromBMI = "obese";
            }
            else
            {
                bodyTypeFromBMI= "extremely obese";
            }
        }

        string modelPickerColor = "";
        private void picker_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            Slider slider = sender as Slider;
            int value = (int)slider.Value;
            if (value <= 25)
            {
                modelPickerColor = "white";
            }
            else if (value <= 50)
            {
                modelPickerColor = "Asian";
            }
            else if (value <= 75)
            {
                modelPickerColor = "Latino";
            }
            else
            {
                modelPickerColor = "black";
            }
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            int limbsNum = int.Parse(tbLimbs.Text);

            if (limbsNum > 0)
            {
                limbsNum--;
                tbLimbs.Text = limbsNum.ToString();
            }
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            int limbsNum = int.Parse(tbLimbs.Text);

            if (limbsNum < 5 && chbMale.IsChecked == true)
            {
                limbsNum++;
                tbLimbs.Text = limbsNum.ToString();
            }
            else if (limbsNum < 4)
            {
                limbsNum++;
                tbLimbs.Text = limbsNum.ToString();
            }
        }


        int minYear = 0;
        private void tbMinYear_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            minYear = int.Parse(t.Text);

            if (minYear != 0 && maxYear != 0)
            {
                Year();
            }
        }
        int maxYear = 0;
        private void tbMaxYear_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            maxYear = int.Parse(t.Text);

            if (minYear != 0 && maxYear != 0)
            {
                Year();
            }

        }
        string age = "";
        private void Year()
        {
            int now = DateTime.Now.Year;
            int year = random.Next(minYear, maxYear+1);

            if (now - year < 10)
            {
                age = "kid under the age of 10";
            }
            else if (now - year < 20)
            {
                age = "in his/her teens";
            }
            else if (now - year < 30)
            {
                age = "in his/her 20s";
            }
            else if (now - year < 40)
            {
                age = "in his/her 30s";
            }
            else if (now - year < 50)
            {
                age = "in his/her 40s";
            }
            else if (now - year < 60)
            {
                age = "in his/her 50s";
            }
            else if (now - year < 70)
            {
                age = "in his/her 60s";
            }
            else if (now - year < 80)
            {
                age = "in his/her 70s";
            }
            else if (now - year < 90)
            {
                age = "in his/her 80s";
            }
            else if (now - year < 100)
            {
                age= "in his/her 90s";
            }
            else
            {
                age = "over the age of 100";
            }
        }

        string background = "";
        private void btnBackgroundYes_Click(object sender, RoutedEventArgs e)
        {
            background = "honest looking person";
        }

        private void btnBackgroundNo_Click(object sender, RoutedEventArgs e)
        {
            background = "possibly criminal";
        }

        string hairColor = "";
        private void btnHairColorClick(object sender, RoutedEventArgs e) 
        {
            Button b = sender as Button;
            System.Drawing.Color col = ColorTranslator.FromHtml(b.Background.ToString());
            hairColor = col.Name.ToLower();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();

            if (chbMale.IsChecked == true && chbFemale.IsChecked == false)
            {
                data.Add("man");
            }
            else if (chbMale.IsChecked == false && chbFemale.IsChecked == true) {
                data.Add("woman");
            }
            else if (chbMale.IsChecked == true && chbFemale.IsChecked == true)
            {
                data.Add("transgender person");
            }
            else
            {
                data.Add("human");
            }

            if (heightForAI != "")
            {
                data.Add(heightForAI);
            }

            if (bodyTypeFromBMI != "")
            {
                data.Add(bodyTypeFromBMI);
            }

            if (modelPickerColor != "")
            {
                data.Add(modelPickerColor);
            }

            if (tbLimbs.Text == "5")
            {
                data.Add("with 4 limbs");
            }
            else
            {
                data.Add($"with {tbLimbs.Text} limbs");
            }

            if (age != "")
            {
                data.Add(age);
            }

            if (background != "")
            {
                data.Add(background);
            }

            if (hairColor != "")
            {
                data.Add($"with {hairColor} hair");
            }

            foreach (var item in data)
            {
                File.WriteAllText("personData.txt", item + ";");
                MessageBox.Show(item);
            }
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
