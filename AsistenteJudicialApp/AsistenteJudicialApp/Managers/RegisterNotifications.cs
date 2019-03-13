using AsistenteJudicialApp.Interfaces;
using Xamarin.Forms;

namespace AsistenteJudicialApp.Managers
{
    class RegisterNotifications
    {
        public RegisterNotifications()
        {
            var register = DependencyService.Get<IRegisterDevice>();
            register.RegisterDevice();
        }
    }
}
