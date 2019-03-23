using AsistenteJudicialApp.Managers;
using AsistenteJudicialApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsistenteJudicialApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detail : ContentPage
	{

        string userid = App.Current.Properties["UserId"].ToString();

        public Detail ()
		{
			InitializeComponent ();
            listarProcesos();
                        
        }

        private async void listarProcesos()
        {

            if (!HayConexion())
            {                
                await DisplayAlert("Atencion", "No tienes conexion a internet para revisar y hacer modificaciones", "Aceptar");
            }

            try
            {
                ProcesoManager manager = new ProcesoManager();
                var response = await manager.getProcesosUser(userid);                

                if (response != null)
                {
                    lstProcesos.ItemsSource = response;
                    App.Current.Properties["procesos"] = response.Count();
                    await App.Current.SavePropertiesAsync();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static bool HayConexion(string huesped = "https://www.google.com.co/")
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(huesped))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void LstProcesos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           Proceso proceso = e.Item as Proceso;
           
           await Navigation.PushAsync(new ProcesoPage(proceso.id));
        }

        private async void AgregarProceso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuscarProcesoPage());
        }

        private void LstProcesos_Refreshing(object sender, EventArgs e)
        {
            listarProcesos();
        }
    }
}