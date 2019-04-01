using AsistenteJudicialApp.Managers;
using AsistenteJudicialApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsistenteJudicialApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProcesoPage : ContentPage
	{
        ProcesoManager manager;        
        Proceso proceso;
        string proceso_id, user_id;
		public ProcesoPage (int id)
		{
			InitializeComponent ();
            manager = new ProcesoManager();
            obtenerProceso(id);

            proceso_id = id.ToString();
            user_id = App.Current.Properties["UserId"].ToString();

        }

        public async void obtenerProceso(int id)
        {
            try
            {
                proceso = await manager.getProceso(id);
                radicacion.Text = proceso.radicacion;
                juzgado.Text = proceso.juzgado;
                demandado.Text = proceso.demandado;
                demandante.Text = proceso.demandante;

                var response = await manager.getEstados(proceso.id.ToString());

                if (response != null)
                {
                    lstEstado.ItemsSource = response;
                }
            }
            catch { }
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirma", "¿Estas seguro de que ya no deseas recibir notificaciones sobre este proceso?", "Si", "No");

            if (answer)
            {
                try
                {
                    manager.detachProcesoUser(user_id,proceso_id);
                    await DisplayAlert("Listo", "Proceso quitado correctamente ", "Aceptar");
                    await Navigation.PushAsync(new MainPage());
                }
                catch
                {
                    await DisplayAlert("Error", "No se pudo quitar el proceso, por favor intenta mas tarde", "Aceptar");
                }
            }
        }

        private async void SolicitarBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                solicitarBtn.IsEnabled = false;
                SolicitudManager manager = new SolicitudManager();
                manager.saveSolicitud(user_id, proceso_id, observacionesEntry.Text);
                await DisplayAlert("Listo", "Solicitud enviada pronto enviaremos el auto al correo", "Aceptar");
                solicitarBtn.IsEnabled = true;
            }
            catch
            {
                await DisplayAlert("Error", "Solicitud no realizada", "Aceptar");
                solicitarBtn.IsEnabled = true;
            }
        }
    }
}