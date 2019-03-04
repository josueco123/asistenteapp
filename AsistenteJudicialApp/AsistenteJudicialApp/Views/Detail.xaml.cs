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
            try
            {
                ProcesoManager manager = new ProcesoManager();
                var response = await manager.getProcesosUser(userid);

                if (response != null)
                {
                    lstProcesos.ItemsSource = response;
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void LstProcesos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           Proceso proceso = e.Item as Proceso;

           //await DisplayAlert("item", proceso.id.ToString(), "aceptar");
           await Navigation.PushAsync(new ProcesoPage(proceso.id));
        }

        private async void AgregarProceso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarProcesoPage());
        }
    }
}