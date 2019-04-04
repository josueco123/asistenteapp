using AsistenteJudicialApp.Managers;
using AsistenteJudicialApp.Models;
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
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }

        private async void ContinuarBtn_Clicked(object sender, EventArgs e)
        {           
            if (string.IsNullOrEmpty(nombreEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un Nombre", "Aceptar");
                nombreEntry.Focus();
                return;
            }
            

            if (string.IsNullOrEmpty(correoEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un Correo", "Aceptar");
                correoEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(passEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un Contraseña", "Aceptar");
                passEntry.Focus();
                return;
            }

            if (!passEntry2.Text.Equals(passEntry.Text))
            {
                await DisplayAlert("Error", "Las contraseñas no son iguales", "Aceptar");
                passEntry2.Focus();
                return;
            }
           
            try
            {
                continuarBtn.IsEnabled = false;
                UserManager manager = new UserManager();
                manager.saveUser(nombreEntry.Text, correoEntry.Text, passEntry.Text);
                continuarBtn.IsEnabled = true;

                /*User user = await manager.loginUser(correoEntry.Text, passEntry.Text);
                App.Current.Properties["UserId"] = user.id;
                App.Current.Properties["name"] = user.name;                
                App.Current.Properties["Email"] = user.email;
                App.Current.Properties["IsLoggedIn"] = Boolean.TrueString;
                await App.Current.SavePropertiesAsync();
                RegisterNotifications registerNotifications = new RegisterNotifications();
                */

                await DisplayAlert("Bienvenido", "Registro realizado correctamente, confirma tus datos iniciando session", "Aceptar");
                await Navigation.PushAsync(new LoginPage());
            }
            catch(Exception ex)
            {
                continuarBtn.IsEnabled = true;
                await DisplayAlert("Lo sentimos", ex.ToString(), "Aceptar");
            }
            

        }

        private void TerminosBtn_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://asistententejudicial.com/docs/Terminos%20y%20Condiciones%20Asistente%20Judicial.pdf"));
        }
    }
}