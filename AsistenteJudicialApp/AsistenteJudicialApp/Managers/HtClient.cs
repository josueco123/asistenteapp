using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AsistenteJudicialApp.Managers
{
    class HtClient
    {
        public HttpClient getCliente()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }
    }
}
