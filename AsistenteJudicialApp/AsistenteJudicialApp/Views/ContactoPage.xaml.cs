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
	public partial class ContactoPage : ContentPage
	{
		public ContactoPage ()
		{
			InitializeComponent ();
		}

        private void TerminosBtn_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://asistententejudicial.com/docs/Terminos%20y%20Condiciones%20Asistente%20Judicial.pdf"));
        }
    }
}