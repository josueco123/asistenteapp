using AsistenteJudicialApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AsistenteJudicialApp.Managers
{
    class UserManager
    {
        HtClient htclient = new HtClient();        

        public async Task<User> loginUser(string email, string password)
        {
            String UT = "https://asistentejudicial.000webhostapp.com/log/" + email + "/" + password;

            HttpClient client = htclient.getCliente();          

            var res = await client.GetAsync(UT);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);

            }

            return null;
        }
    }
}
