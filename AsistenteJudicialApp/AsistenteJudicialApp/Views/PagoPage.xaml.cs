﻿using AsistenteJudicialApp.Managers;
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
	public partial class PagoPage : ContentPage
	{
		public PagoPage ()
		{
			InitializeComponent ();
            string cantidad = App.Current.Properties["procesos"].ToString();
            cantidaLabel.Text = "Actualmente tienes "+ cantidad + " procesos registrados";
		}

        private async void PagopsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PagoPSEPage());

        }

        private async void RecibirBtn_Clicked(object sender, EventArgs e)
        {
            string id = App.Current.Properties["UserId"].ToString();
            string num = App.Current.Properties["procesos"].ToString();

            bool answer = await DisplayAlert("", "¿Deseas que por este mes te revisemos estos "+ num + " procesos?", "Sí", "No");

            if (answer)
            {
                recibirBtn.IsEnabled = false;                
                try
                {
                    UserManager manager = new UserManager();
                    manager.infoPagos(id, num);
                    recibirBtn.IsEnabled = true;
                    await DisplayAlert("Listo", "Te hemos enviado un correo con la informacion para que realices tu pago", "Aceptar");

                }
                catch
                {
                    recibirBtn.IsEnabled = true;
                    await DisplayAlert("", "Se ha presentado un error y no hemos podido enviarte el correo, por favor intenta más tarde", "Aceptar");

                }
            }
            
           
           
        }
    }
}