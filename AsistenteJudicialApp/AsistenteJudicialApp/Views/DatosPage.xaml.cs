using AsistenteJudicialApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace AsistenteJudicialApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosPage : ContentPage
    {
        
        int id;

        public DatosPage()
		{
			InitializeComponent ();
                        
           
            id = Convert.ToInt32(App.Current.Properties["UserId"].ToString());
		}

       

        private async void GuardarBtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cedulaEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar la Ceudula", "Aceptar");
                cedulaEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(telefonoEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un numero de Telefono", "Aceptar");
                telefonoEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(direccionEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un numero de Direccion", "Aceptar");
                direccionEntry.Focus();
                return;
            }

            try
            {
                guardarBtn.IsEnabled = false;                
                DatosManager datosManager = new DatosManager();                
                datosManager.saveDatos(id,cedulaEntry.Text, telefonoEntry.Text, direccionEntry.Text);
                guardarBtn.IsEnabled = true;
                await DisplayAlert("Bienvenido", "Registro creado Correctamente", "Aceptar");
                
                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudo realizar el registro revisa tu conexion a internet ", "Aceptar");               
                guardarBtn.IsEnabled = true;
            }
        }
    }
}