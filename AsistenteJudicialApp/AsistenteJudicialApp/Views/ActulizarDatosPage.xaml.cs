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
        Userdato userdato;
        int idUser;
		public ActulizarDatosPage ()
		{
			InitializeComponent ();
            
            userManager = new UserManager();
            idUser = Convert.ToInt32(App.Current.Properties["UserId"].ToString());
            ObtenerDatos(idUser);
		}

        public async void ObtenerDatos(int id)
        {
            try
            {
                
                user = await userManager.getUser(id);
                nombreEntry.Text = user.name;
                
                correoEntry.Text = user.email;
               
            }
            catch (Exception ex)
            {
                await DisplayAlert("error", ex.ToString(), "ok");
            }

        }

        private async void ActulizarBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                userManager.updateUser(idUser, nombreEntry.Text, correoEntry.Text);
                //manager.updateDatos(idUser, apellidoEntry.Text, cedulaEntry.Text, telefonoEntry.Text, direccionEntry.Text);
                await DisplayAlert("Perfecto", "Datos Actualizados", "Aceptar");
                await Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {
                await DisplayAlert("error", ex.ToString(), "ok");
            }
        }
    }
}