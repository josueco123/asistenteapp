using AsistenteJudicialApp.Managers;
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
    public partial class ClavePage : ContentPage
    {
        public ClavePage()
        {
            InitializeComponent();
        }

        private async void Passbtn_Clicked(object sender, EventArgs e)
        {
            passbtn.IsEnabled = false;
            UserManager manager = new UserManager();
            manager.changePass(correoEntry.Text);            
            await DisplayAlert("Listo", "Te hemos enviado un correo para que hagas el cambio", "Aceptar");
            passbtn.IsEnabled = true;
            await Navigation.PopAsync();
        }
    }
}