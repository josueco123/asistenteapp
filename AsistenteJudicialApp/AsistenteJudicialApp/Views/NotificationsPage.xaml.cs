using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Notifications;
using AsistenteJudicialApp.Managers;
using AsistenteJudicialApp.Models;

namespace AsistenteJudicialApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotificationsPage : ContentPage
	{        
        public NotificationsPage ()
		{
			InitializeComponent ();
            listarNotificaciones();

        }

        private async void listarNotificaciones()
        {
            string userid = App.Current.Properties["UserId"].ToString();

            try
            {
                InformesManager manager = new InformesManager();
                var informes = await manager.getInformesUser(userid);

                if(informes != null)
                {
                    lstNotificaciones.ItemsSource = informes;
                }
            }catch
            {

            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            

            //CrossNotifications.Current.SetBadge(cantidad);                    


        }

        private async void LstNotificaciones_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Informe informe = e.Item as Informe;
            //await DisplayAlert("item", informe.proceso_id, "aceptar");
            await Navigation.PushAsync(new ProcesoPage(Convert.ToInt32(informe.proceso_id)));
        }
    }
}