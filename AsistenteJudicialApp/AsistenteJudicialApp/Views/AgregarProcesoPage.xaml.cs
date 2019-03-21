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
	public partial class AgregarProcesoPage : ContentPage
	{
        ProcesoManager manager;
        List<Juzgado> juzgados;
        string radicacion;
        string juzgadoProceso;
        string userid = App.Current.Properties["UserId"].ToString();
        public AgregarProcesoPage (string radicacion)
		{
			InitializeComponent ();
            InitPickerJuzgado();
            manager = new ProcesoManager();
            this.radicacion = radicacion;
            radicacionLabel.Text = radicacion;
        }        

        private void JuzgadoTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            juzgadoNumero.Items.Clear();

            int position = juzgadoTipo.SelectedIndex;            
            if (position > -1)
            {
                foreach(var numeros in juzgados[position].numero)
                {
                    juzgadoNumero.Items.Add(numeros);
                }
            }
        }       

        private void JuzgadoNumero_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                juzgadoProceso = juzgadoNumero.SelectedItem.ToString();
            }
            catch
            {

            }                        
        }

        private async void GuadarProceso_Clicked(object sender, EventArgs e)
        {
            

            if (string.IsNullOrEmpty(juzgadoProceso))
            {
                await DisplayAlert("Error", "Debe ingresar un Juzgado", "Aceptar");                
                return;
            }


            if (string.IsNullOrEmpty(demandadoEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un Demandado", "Aceptar");
                demandadoEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(demandanteEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un Demandante", "Aceptar");
                demandanteEntry.Focus();
                return;
            }

            ProcesoManager manager = new ProcesoManager();
            try
            {                
                manager.saveProcesoUser(radicacion, demandanteEntry.Text, demandadoEntry.Text, juzgadoProceso, userid);
                //var res = await manager.saveProceso(radicacionEntry.Text, demandanteEntry.Text, demandadoEntry.Text, juzgadoProceso);
                await DisplayAlert("Listo", "Proceso agregado Correctamente", "Aceptar");
                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.ToString(), "Aceptar");
            }
        }

        void InitPickerJuzgado()
        {
            List<string> civiles = new List<string>();
            civiles.Add("Juzgado primero Civil");
            civiles.Add("Juzgado segundo Civil");
            List<string> laborales = new List<string>();
            laborales.Add("Juzgado Primero Laboral");
            laborales.Add("Juzgado Segundo Laboral");
            laborales.Add("Juzgado Tercero Laboral");
            juzgados = new List<Juzgado>();
            juzgados.Add(new Juzgado { name = "juzgados civiles", numero = civiles });
            juzgados.Add(new Juzgado { name = "juzgados Laborales", numero = laborales });

            foreach (var juzgado in juzgados)
            {
                juzgadoTipo.Items.Add(juzgado.name);
            }

        }
        
    }
}