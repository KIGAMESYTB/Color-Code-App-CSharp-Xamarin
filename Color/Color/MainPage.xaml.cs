using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Drawing;

namespace Color
{
    public partial class MainPage : ContentPage
    {
        Random random;
        int red;
        int green;
        int blue;
        int countBtn;

        public MainPage()
        {
            InitializeComponent();
            random = new Random();
            countBtn = 0;
            randomColor();
            textCode();
            backkgroundColorElement();
            slideValue();
        }

        private void backkgroundColorElement()
        {
            boxColor.BackgroundColor = Xamarin.Forms.Color.FromRgb(red, green, blue);
            boxBlue.BackgroundColor = Xamarin.Forms.Color.FromRgb(0, 0, blue);
            boxRed.BackgroundColor = Xamarin.Forms.Color.FromRgb(red, 0, 0);
            boxGreen.BackgroundColor = Xamarin.Forms.Color.FromRgb(0, green, 0);
        }

        private void randomColor()
        {
            red = random.Next(255);
            blue = random.Next(255);
            green = random.Next(255);
        }

        private void textCode()
        {
            String hexaRed = red.ToString("X");
            String hexaBlue = blue.ToString("X");
            String hexaGreen = green.ToString("X");

            if (hexaBlue == "0") hexaBlue = "00";
            else if (hexaRed == "0") hexaRed = "00";
            else if (hexaGreen == "0") hexaGreen = "00";

            decimalCode.Text = (red) + "," + (green) + "," + (blue);
            hexadecimalCode.Text = "#" + hexaRed + hexaGreen + hexaBlue;
        }

        private void slideColor(object sender, ValueChangedEventArgs e)
        {
            red = (int)slideRed.Value;
            green = (int)slideGreen.Value;
            blue = (int)slideBlue.Value;

            textCode();
            backkgroundColorElement();
        }

        private void slideValue()
        {
            slideBlue.Value = blue;
            slideGreen.Value = green;
            slideRed.Value = red;
        }

        private void btnChange_Clicked(object sender, EventArgs e)
        {
            if (countBtn % 2 == 0)
            {
                btnChange.Text = "personalize";
            }
            else
            {
                btnChange.Text = "Random";
            }
            slideStackLayout.IsVisible = !slideStackLayout.IsVisible;
            randomStackLayout.IsVisible = !randomStackLayout.IsVisible;
            countBtn++;
            slideValue();
        }


        private void btnChangeColorRandom_Clicked(object sender, EventArgs e)
        {
            randomColor();
            textCode();
            backkgroundColorElement();
        }
    }
}

