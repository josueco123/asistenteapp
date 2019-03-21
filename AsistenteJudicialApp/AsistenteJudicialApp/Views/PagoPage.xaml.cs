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
		}

        private async void PagopsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PagoPSEPage());

        }
    }
}