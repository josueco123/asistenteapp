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
	public partial class ActulizarDatosPage : ContentPage
	{
        
        UserManager userManager;
        User user;        
        DatosManager manager;
        int idUser;
		public ActulizarDatosPage ()
		{
			InitializeComponent ();
            
            userManager = new UserManager();
            manager = new DatosManager();
            idUser = Convert.ToInt32(App.Current.Properties["UserId"].ToString());
            ObtenerDatos(idUser);
		}

        public async void ObtenerDatos(int id)
        {
            try
            {
                var datos = await manager.getDatos(id);
                user = await userManager.getUser(id);

                nombreEntry.Text = user.name;                
                correoEntry.Text = user.email;

                if(!(datos == null))
                {
                    cedulaEntry.Text = datos.identificacion;
                    telefonoEntry.Text = datos.telefono;
                    direccionEntry.Text = datos.direccion;
                }
               
            }
            catch 
            {
                await DisplayAlert("Error", "No tienes conexion a internet", "Aceptar");
            }

        }

        private async void ActulizarBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                userManager.updateUser(idUser, nombreEntry.Text, correoEntry.Text);
                App.Current.Properties["name"] = nombreEntry.Text;                
                App.Current.Properties["Email"] = correoEntry.Text;
                await App.Current.SavePropertiesAsync();
                await DisplayAlert("Excelente", "Datos Actualizados", "Aceptar");
                await Navigation.PushAsync(new MainPage());

            }
            catch 
            {
                await DisplayAlert("Error", "Ha ocurrido un error al actulizar los datos", "Aceptar");
            }
        }

        private async void ContactoBtn_Clicked(object sender, EventArgs e)
        {
            

            try
            {
                manager.saveDatos(idUser, cedulaEntry.Text, telefonoEntry.Text, direccionEntry.Text);
                await DisplayAlert("Perfecto", "Datos Actualizados", "Aceptar");
                await Navigation.PushAsync(new MainPage());
            }
            catch
            {
                await DisplayAlert("Error", "Ha ocurrido un error al actulizar los datos", "Aceptar");
            }
        }
    }
}