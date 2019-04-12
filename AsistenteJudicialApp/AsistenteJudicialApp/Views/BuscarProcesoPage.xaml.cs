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
	public partial class BuscarProcesoPage : ContentPage
	{
        ProcesoManager manager;
        public BuscarProcesoPage ()
		{
			InitializeComponent ();
            manager = new ProcesoManager();
        }

        private async void BuscarProceso_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(radicacionEntry.Text)){             
                await DisplayAlert("Error", "Debe ingresar un numero de radicacion", "Aceptar");
                radicacionEntry.Focus();
                return;
            }

            if (radicacionEntry.Text.Length < 7){
                await DisplayAlert("Error", "Debes ingresar los siete ultimos numeros de la radicacion del proceso", "Aceptar");
                radicacionEntry.Focus();
                return;
            }

            try
            {
                buscarProceso.IsEnabled = false;
                var response = await manager.getProcesoRadicacion(radicacionEntry.Text);
                buscarProceso.IsEnabled = true;
                if (!(response == null))
                {
                    agregarProceso.IsEnabled = true;

                    juzgadoLabel.Text = response.juzgado;
                    demandanteLabel.Text = response.demandante;
                    demandadoLabel.Text = response.demandado;
                }
                else
                {
                    await DisplayAlert("", "Por favor Cuentanos en que Juzgado se encuentra tu proceso", "Aceptar");
                    await Navigation.PushAsync(new AgregarProcesoPage(radicacionEntry.Text));
                }
            }
            catch
            {

            }
        }
        private async void AgregarProceso_Clicked(object sender, EventArgs e)
        {
            string id = App.Current.Properties["UserId"].ToString();
            try
            {
                agregarProceso.IsEnabled = false;
                 manager.addProcesoUser(id, radicacionEntry.Text);
                await DisplayAlert("Listo", "proceso añadido exitosamente", "Aceptar");
                agregarProceso.IsEnabled = true;
                await Navigation.PushAsync(new MainPage());
            }
            catch
            {
                await DisplayAlert("Error", "proceso no anadido", "Aceptar");
            }
        }
    }
}