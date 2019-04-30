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
            civiles.Add("Juzgado Primero Civil Municipal");
            civiles.Add("Juzgado Segundo Civil Municipal");
            civiles.Add("Juzgado Tercero Civil Municipal");
            civiles.Add("Juzgado Cuarto Civil Municipal");
            civiles.Add("Juzgado Quinto Civil Municipal");
            civiles.Add("Juzgado Sexto Civil Municipal");
            civiles.Add("Juzgado Septimo Civil Municipal");
            civiles.Add("Juzgado Octavo Civil Municipal");
            civiles.Add("Juzgado Noveno Civil Municipal");
            civiles.Add("Juzgado Decimo Civil Municipal");
            civiles.Add("Juzgado Once Civil Municipal");
            civiles.Add("Juzgado Doce Civil Municipal");
            civiles.Add("Juzgado Trece Civil Municipal");
            civiles.Add("Juzgado Catorce Civil Municipal");
            civiles.Add("Juzgado Quince Civil Municipal");
            civiles.Add("Juzgado Diesiseis Civil Municipal");
            civiles.Add("Juzgado Diecisiente Civil Municipal");
            civiles.Add("Juzgado Diesiocho Civil Municipal");
            civiles.Add("Juzgado Diesinueve Civil Municipal");
            civiles.Add("Juzgado Veinte Civil Municipal");
            civiles.Add("Juzgado Veintiuno Civil Municipal");
            civiles.Add("Juzgado Veintidos Civil Municipal");
            civiles.Add("Juzgado Veintitres Civil Municipal");
            civiles.Add("Juzgado Veinticuarto Civil Municipal");
            civiles.Add("Juzgado Veinticinco Civil Municipal");
            civiles.Add("Juzgado Veintiseis Civil Municipal");
            civiles.Add("Juzgado Veintisiete Civil Municipal");
            civiles.Add("Juzgado Veintiocho Civil Municipal");
            civiles.Add("Juzgado Veintinueve Civil Municipal");
            civiles.Add("Juzgado Treinta Civil Municipal");
            civiles.Add("Juzgado Treinta Y Uno Civil Municipal");
            civiles.Add("Juzgado Treinta Y Dos Civil Municipal");
            civiles.Add("Juzgado Treinta Y Tres Civil Municipal");
            civiles.Add("Juzgado Treinta Y Cuatro Civil Municipal");
            civiles.Add("Juzgado Treinta Y Cinco Civil Municipal");

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

            List<string> civilc = new List<string>();
            civilc.Add("Juzgado Primero Civil del Circuito");
            civilc.Add("Juzgado Segundo Civil del Circuito");
            civilc.Add("Juzgado Tercero Civil del Circuito");
            civilc.Add("Juzgado Cuarto Civil del Circuito");
            civilc.Add("Juzgado Quinto Civil del Circuito");
            civilc.Add("Juzgado Sexto Civil del Circuito");
            civilc.Add("Juzgado Septimo Civil del Circuito");
            civilc.Add("Juzgado Octavo Civil del Circuito");
            civilc.Add("Juzgado Noveno Civil del Circuito");
            civilc.Add("Juzgado Decimo Civil del Circuito");
            civilc.Add("Juzgado Once Civil del Circuito");
            civilc.Add("Juzgado Doce Civil del Circuito");
            civilc.Add("Juzgado Trece Civil del Circuito");
            civilc.Add("Juzgado Catorce Civil del Circuito");
            civilc.Add("Juzgado Quince Civil del Circuito");
            civilc.Add("Juzgado Diesiseis Civil del Circuito");
            civilc.Add("Juzgado Diesisiete Civil del Circuito");
            civilc.Add("Juzgado Disiocho Civil del Circuito");
            civilc.Add("Juzgado Diesinueve Civil del Circuito");

            List<string> familia = new List<string>();
            familia.Add("Juzgado Primero de Familia");
            familia.Add("Juzgado Segundo de Familia");
            familia.Add("Juzgado Tercero de Familia");
            familia.Add("Juzgado Cuarto de Familia");
            familia.Add("Juzgado Quinto de Familia");
            familia.Add("Juzgado Sexto de Familia");
            familia.Add("Juzgado Septimo de Familia");
            familia.Add("Juzgado Octavo de Familia");
            familia.Add("Juzgado Noveno de Familia");
            familia.Add("Juzgado Decilmo de Familia");
            familia.Add("Juzgado Once de Familia");
            familia.Add("Juzgado Doce de Familia");
            familia.Add("Juzgado Trece de Familia");
            familia.Add("Juzgado Catorce de Familia");

            List<string> superior = new List<string>();
            superior.Add("Sala Laboral");
            superior.Add("Sala Civil");
            superior.Add("Sala Familia");

            List<string> causasl = new List<string>();
            causasl.Add("Juzgado Primero de Pequeñas Causas Laborales");
            causasl.Add("Juzgado Segundo de Pequeñas Causas Laborales");
            causasl.Add("Juzgado Tercero de Pequeñas Causas Laborales");
            causasl.Add("Juzgado Cuarto de Pequeñas Causas Laborales");
            causasl.Add("Juzgado Quinto de Pequeñas Causas Laborales");
            causasl.Add("Juzgado Sexto de Pequeñas Causas Laborales");

            List<string> amdOr = new List<string>();
            amdOr.Add("Juzgado Primero Administrativo de Oralidad");
            amdOr.Add("Juzgado Segundo Administrativo de Oralidad");
            amdOr.Add("Juzgado Tercero Administrativo de Oralidad");
            amdOr.Add("Juzgado Cuarto Administrativo de Oralidad");
            amdOr.Add("Juzgado Quinto Administrativo de Oralidad");
            amdOr.Add("Juzgado Sexto Administrativo de Oralidad");
            amdOr.Add("Juzgado Septimo Administrativo de Oralidad");
            amdOr.Add("Juzgado Octavo Administrativo de Oralidad");
            amdOr.Add("Juzgado Noveno Administrativo de Oralidad");
            amdOr.Add("Juzgado Decimo Administrativo de Oralidad");
            amdOr.Add("Juzgado Once Administrativo de Oralidad");
            amdOr.Add("Juzgado Doce Administrativo de Oralidad");
            amdOr.Add("Juzgado Trece Administrativo de Oralidad");
            amdOr.Add("Juzgado Catorce Administrativo de Oralidad");
            amdOr.Add("Juzgado Quince Administrativo de Oralidad");
            amdOr.Add("Juzgado Diesiseis Administrativo de Oralidad");
            amdOr.Add("Juzgado Diesisiete Administrativo de Oralidad");
            amdOr.Add("Juzgado Diesiocho Administrativo de Oralidad");
            amdOr.Add("Juzgado Diesinueve Administrativo de Oralidad");
            amdOr.Add("Juzgado Veinte Administrativo de Oralidad");
            amdOr.Add("Juzgado Veintiuno Administrativo de Oralidad");

            List<string> civilme = new List<string>();
            civilme.Add("Juzgado Primero Civil Municipal de Ejecución");
            civilme.Add("Juzgado Segundo Civil Municipal de Ejecución");
            civilme.Add("Juzgado Tercero Civil Municipal de Ejecución");
            civilme.Add("Juzgado Cuarto Civil Municipal de Ejecución");
            civilme.Add("Juzgado Quinto Civil Municipal de Ejecución");
            civilme.Add("Juzgado Sexto Civil Municipal de Ejecución");
            civilme.Add("Juzgado Septimo Civil Municipal de Ejecución");
            civilme.Add("Juzgado Octavo Civil Municipal de Ejecución");
            civilme.Add("Juzgado Noveno Civil Municipal de Ejecución");
            civilme.Add("Juzgado Decimo Civil Municipal de Ejecución");

            List<string> civilce = new List<string>();
            civilce.Add("Juzgado Primero Civil del Circuito de Ejecución");
            civilce.Add("Juzgado Segundo Civil del Circuito de Ejecución");
            civilce.Add("Juzgado Tercero Civil del Circuito de Ejecución");

            juzgados = new List<Juzgado>();
            juzgados.Add(new Juzgado { name = "Juzgados Civiles Municipales", numero = civiles });
            juzgados.Add(new Juzgado { name = "Juzgados Civiles del Circuito", numero = civilc });
            juzgados.Add(new Juzgado { name = "Juzgados Laborales", numero = laborales });
            juzgados.Add(new Juzgado { name = "Juzgados de Familia ", numero = familia });
            juzgados.Add(new Juzgado { name = "Tribunal Superior Cali", numero = superior });
            juzgados.Add(new Juzgado { name = "Juzgados de Pequeñas Causas Laborales", numero = causasl });
            juzgados.Add(new Juzgado { name = "Juzgados Administrativos de Oralidad", numero = amdOr });
            //juzgados.Add(new Juzgado { name = "Juzgados Administrativos del Circuito", numero = laborales });
            juzgados.Add(new Juzgado { name = "Juzgados Civiles Municipales de Ejecución", numero = civilme });
            juzgados.Add(new Juzgado { name = "Juzgados Civiles del Circuito de Ejecución", numero = civilce });

            foreach (var juzgado in juzgados)
            {
                juzgadoTipo.Items.Add(juzgado.name);
            }

        }
        
    }
}