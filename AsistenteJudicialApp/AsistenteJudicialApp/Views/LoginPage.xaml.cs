using AsistenteJudicialApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsistenteJudicialApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);            
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(correoEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un correo", "Aceptar");
                correoEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(passEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un clave", "Aceptar");
                passEntry.Focus();
                return;
            }

            
            try
            {
                login.IsEnabled = false;
                indicator.IsRunning = true;
                UserManager manager = new UserManager();

                var res = await manager.loginUser(correoEntry.Text, passEntry.Text);               

                login.IsEnabled = true;
                indicator.IsRunning = false;
                App.Current.Properties["IsLoggedIn"] = Boolean.TrueString;
                App.Current.Properties["name"] = res.name.ToString();
                App.Current.Properties["UserId"] = res.id.ToString();
                App.Current.Properties["Email"] = res.email.ToString();
                await App.Current.SavePropertiesAsync();
                RegisterNotifications registerNotifications = new RegisterNotifications();
                await Navigation.PushAsync(new MainPage());
            }
            catch 
            {
                await DisplayAlert("Error", "Email o contraseña incorretos ", "Aceptar");
                login.IsEnabled = true;
                indicator.IsRunning = false;
            }

        }


        private async void RegistroBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPage());
        }


        protected override bool OnBackButtonPressed()
        {
            return true;
        }

       
    }
}