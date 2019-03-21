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
    public partial class Master : ContentPage
    {        
        public Master ()
		{
			InitializeComponent ();
            nameLabel.Text = App.Current.Properties["name"].ToString();

        }

        private async void CerrarSesion_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties["IsLoggedIn"] = Boolean.FalseString;
            App.Current.Properties["name"] = string.Empty;
            App.Current.Properties["UserId"] = string.Empty;
            App.Current.Properties["Email"] = string.Empty;
            await App.Current.SavePropertiesAsync();

            await Navigation.PushAsync(new LoginPage());
        }

        private async void NotificacionesNtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotificationsPage());
        }

        private async void ActualizarNtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActulizarDatosPage());
        }

        private async void PagosBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PagoPage());
        }
    }
}