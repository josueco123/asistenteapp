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
	public partial class Master : ContentPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        private async void CerrarSesion_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties["IsLoggedIn"] = Boolean.FalseString;

            await Navigation.PushAsync(new LoginPage());
        }
    }
}