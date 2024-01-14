using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GallaryApp.Pages
{
    public partial class PinPage : ContentPage
    {
        private const string PIN_KEY = "pin";
        private string pincode;

        public PinPage()
        {
            InitializeComponent();

            if (Preferences.Get(PIN_KEY, null) != null)
            {
                MessageLabel.Text = "";
                SavePinButton.IsVisible = false;
            }
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            pincode = PinEntry.Text;

            if (string.IsNullOrEmpty(pincode) || pincode.Length < 4)
            {
                MessageLabel.Text = "Пин код должен быть больше 4-х цифры.";
                return;
            }

            Preferences.Set(PIN_KEY, pincode);
            SavePinButton.IsVisible = false;
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            if (PinEntry.Text == Preferences.Get(PIN_KEY, pincode))
            {
                Navigation.PushAsync(new GallaryPage());
            }
            else
            {
                MessageLabel.Text = "Неправильный пароль!";
            }
        }
    }
}