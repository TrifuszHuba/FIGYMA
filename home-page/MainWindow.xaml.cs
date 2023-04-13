using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;

namespace home_page
{
    public partial class MainWindow : Window
    {
        Random random = new Random();
        List<Image> peopleImages = new List<Image>();
        List<string> peopleBios = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
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

        Button buttonCondition;
        private void borderBoldCondition_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            b.BorderThickness = new Thickness(5);
            b.BorderBrush = Brushes.Black;
            if (buttonCondition != null && buttonCondition != b)
            {
                buttonCondition.BorderThickness = new Thickness(1);
            }
            buttonCondition = b;
        }

        Button buttonWeight;
        private void borderBoldWeight_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            b.BorderThickness = new Thickness(5);
            b.BorderBrush = Brushes.Black;
            if (buttonWeight != null && buttonWeight != b)
            {
                buttonWeight.BorderThickness = new Thickness(1);
            }
            buttonWeight = b;
        }

        Button buttonBackground;
        private void borderBoldBackground_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            b.BorderThickness = new Thickness(5);
            b.BorderBrush = Brushes.Black;
            if (buttonBackground != null && buttonBackground != b)
            {
                buttonBackground.BorderThickness = new Thickness(1);
            }
            buttonBackground = b;
        }

        Button buttonHair;
        private void borderBoldHair_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            b.BorderThickness = new Thickness(5);
            b.BorderBrush = Brushes.Black;
            if (buttonHair != null && buttonHair != b)
            {
                buttonHair.BorderThickness = new Thickness(1);
            }
            buttonHair = b;
        }

        Button buttonPapers;
        private void borderBoldPapers_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            b.BorderThickness = new Thickness(5);
            b.BorderBrush = Brushes.Black;
            if (buttonPapers != null && buttonPapers != b)
            {
                buttonPapers.BorderThickness = new Thickness(1);
            }
            buttonPapers = b;
        }

        Button buttonLocation;
        private void borderBoldLocation_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            b.BorderThickness = new Thickness(5);
            b.BorderBrush = Brushes.Black;
            if (buttonLocation != null && buttonLocation != b)
            {
                buttonLocation.BorderThickness = new Thickness(1);
            }
            buttonLocation = b;
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
            else
            {
                weight = 300;
            }
            borderBoldWeight_Click(sender,e);
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
            else if (bmi < 40)
            {
                bodyTypeFromBMI= "extremely obese";
            }
            else
            {
                bodyTypeFromBMI = "fattest person on the world";
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

            if (now - year < 18)
            {
                age = "teenager";
            }
            else if (now - year >= 18 && now - year <= 25)
            {
                age = "young adult";
            }
            else if (now - year >= 26 && now - year <= 40)
            {
                age = "adult";
            }
            else if (now - year >= 41 && now - year <= 65)
            {
                age = "middle aged";
            }
            else if (now - year >= 66 && now - year <= 85)
            {
                age = "old";
            }
            else
            {
                age = "very old";
            }

        }


        string hairColor = "";
        private void btnHairColorClick(object sender, RoutedEventArgs e) 
        {
            Button b = sender as Button;
            System.Drawing.Color col = ColorTranslator.FromHtml(b.Background.ToString());
            hairColor = col.Name.ToLower();
            borderBoldHair_Click(sender,e);
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

            if (int.Parse(tbLimbs.Text) < 4)
            {
                data.Add("disabled");
            }
            else
            {
                data.Add(" ");
            }

            if (age != "")
            {
                data.Add(age);
            }

            if (hairColor != "")
            {
                data.Add(hairColor);
            }

            foreach (var item in data)
            {
                File.WriteAllText("personData.txt", item + ";");
            }

            Process process = new Process();
            process.StartInfo.FileName = "python";
            process.StartInfo.Arguments = "/image_generation.py";
            process.Start();
            process.WaitForExit();

            process.StartInfo.FileName = "python";
            process.StartInfo.Arguments = "/bio_generation.py";
            process.Start();
            process.WaitForExit();

            for (int i = 0; i < 5; i++)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri($"/image{i}.jpg", UriKind.Relative));
                peopleImages.Add(img);
                peopleBios.Add($"/bio{i}.txt");
            }

            picture.Source = peopleImages[0].Source;
            index= 0;
            personDataWrite();
        }

        int index;
        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                picture.Source = peopleImages[index-1].Source;
                index--;
            }
            else
            {
                picture.Source = peopleImages[peopleImages.Count-1].Source;
            }
            personDataWrite();
            if (greenBorder != null)
            {
                greenBorder.Visibility = Visibility.Visible;
            }
            else
            {
                greenBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (index < peopleBios.Count-1)
            {
                picture.Source = peopleImages[index + 1].Source;
                index++;
            }
            else
            {
                picture.Source = peopleImages[0].Source;
            }
            personDataWrite();
            if (greenBorder != null)
            {
                greenBorder.Visibility = Visibility.Visible;
            }
            else
            {
                greenBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void personDataWrite()
        {
            string bio = File.ReadAllLines($"/bio{index}.txt").ToString();
            personData.Text = bio;
        }

        private void NObutton_Click(object sender, RoutedEventArgs e)
        {
            peopleImages.Remove(peopleImages[index]);
            peopleBios.Remove(peopleBios[index]);
            index--;
            nextButton_Click(nextButton,null);
        }

        private void YESbutton_Click(object sender, RoutedEventArgs e)
        {
            int rnd2 = random.Next(1,101);
            if (rnd2 < 100)
            {
                MessageBox.Show("IT'S A MATCH!");
                greenBorder.Margin = new Thickness(picture.Margin.Left - 2, picture.Margin.Top - 2, 0, 0);
                greenBorder.Visibility = Visibility.Visible;
                // border of hearts
            }
        }
    }
}
