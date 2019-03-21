using AsistenteJudicialApp.Views;
using Plugin.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AsistenteJudicialApp
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();            
            NavigationPage.SetHasNavigationBar(this, false);
            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail());

            App.Masterdetail = this;
        }
    }
}
