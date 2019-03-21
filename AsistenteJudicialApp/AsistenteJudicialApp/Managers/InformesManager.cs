using AsistenteJudicialApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsistenteJudicialApp.Managers
{
    class InformesManager
    {
        HtClient htclient = new HtClient();

        public async Task<IEnumerable<Informe>> getInformesUser(string id)
        {
            String URL = "http://asistententejudicial.com/informes/" + id;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Informe>>(content);

            }

            return Enumerable.Empty<Informe>();
        }
    }
}
