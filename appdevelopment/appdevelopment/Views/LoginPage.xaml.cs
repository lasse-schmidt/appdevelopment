using appdevelopment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appdevelopment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            LoginService service = new LoginService();
            var getLoginDetails = await service.CheckLoginIfExists(Email.Text);
            
            if (getLoginDetails)
            {
                await DisplayAlert("Login Successfull", "", "Okay", "Cancel");
                await Shell.Current.GoToAsync($"//{nameof(GalleryPage)}");
            }
            else if (Email.Text == null)
            {
                await DisplayAlert("Login failed", "Enter your Username/Email and Password before login", "Okay", "Cancel");
            }
            else
            {
                await DisplayAlert("Login failed", "Username/Email or Password is incorrect or does not exists", "Okay", "Cancel");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }
    }
}