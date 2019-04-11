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
	public partial class PagoPage : ContentPage
	{
		public PagoPage ()
		{
			InitializeComponent ();
            string cantidad = App.Current.Properties["procesos"].ToString();
            cantidaLabel.Text = "Actualmente tienes "+ cantidad + " procesos registrados";
		}

        private async void PagopsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PagoPSEPage());

        }

        private async void RecibirBtn_Clicked(object sender, EventArgs e)
        {
            recibirBtn.IsEnabled = false;
            string id = App.Current.Properties["UserId"].ToString();
            string num = App.Current.Properties["procesos"].ToString();
            try
            {
                UserManager manager = new UserManager();
                manager.infoPagos(id, num);
                recibirBtn.IsEnabled = true;
                await DisplayAlert("Listo", "Te hemos enviado un correo con la informacion para que realizces tu pago", "Aceptar");
                
            }
            catch(Exception ex)
            {
                recibirBtn.IsEnabled = true;
                await DisplayAlert("Listo", ex.ToString(), "Aceptar");
                
            }
           
           
        }
    }
}