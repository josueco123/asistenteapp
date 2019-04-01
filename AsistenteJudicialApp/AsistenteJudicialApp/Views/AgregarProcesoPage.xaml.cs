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


            

            ProcesoManager manager = new ProcesoManager();
            try
            {                
                manager.saveProcesoUser(radicacion, juzgadoProceso, userid);
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
            laborales.Add("Juzgado Cuarto Laboral");
            laborales.Add("Juzgado Quinto Laboral");
            laborales.Add("Juzgado Sexto Laboral");
            laborales.Add("Juzgado Septimo Laboral");
            laborales.Add("Juzgado Octavo Laboral");
            laborales.Add("Juzgado Noveno Laboral");
            laborales.Add("Juzgado Decimo Laboral");
            laborales.Add("Juzgado Once Laboral");
            laborales.Add("Juzgado Doce Laboral");
            laborales.Add("Juzgado Trece Laboral");
            laborales.Add("Juzgado Catorce Laboral");
            laborales.Add("Juzgado Quince Laboral");
            laborales.Add("Juzgado Diesiseis Laboral");
            laborales.Add("Juzgado Diesisiete Laboral");
            laborales.Add("Juzgado Diesiocho Laboral");
            juzgados = new List<Juzgado>();
            juzgados.Add(new Juzgado { name = "Juzgados Civiles Municipales", numero = civiles });
            juzgados.Add(new Juzgado { name = "Juzgados Civiles del Circuito", numero = civiles });
            juzgados.Add(new Juzgado { name = "Juzgados Laborales", numero = laborales });
            juzgados.Add(new Juzgado { name = "Juzgados de Familia ", numero = laborales });
            juzgados.Add(new Juzgado { name = "Tribunal Superior Cali", numero = laborales });
            juzgados.Add(new Juzgado { name = "Juzgados de Pequeñas Causas Laborales", numero = laborales });
            juzgados.Add(new Juzgado { name = "Juzgados Administrativos de Oralidad", numero = laborales });
            juzgados.Add(new Juzgado { name = "Juzgados Administrativos del Circuito", numero = laborales });
            juzgados.Add(new Juzgado { name = "Juzgados Civiles Municipales de Ejecucion", numero = laborales });
            juzgados.Add(new Juzgado { name = "Juzgados Civiles del Circuito de Ejecucion", numero = civiles });

            foreach (var juzgado in juzgados)
            {
                juzgadoTipo.Items.Add(juzgado.name);
            }

        }
        
    }
}