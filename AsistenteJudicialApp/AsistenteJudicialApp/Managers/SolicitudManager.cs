using AsistenteJudicialApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AsistenteJudicialApp.Managers
{
    class SolicitudManager
    {
        HtClient htclient = new HtClient();

        public async void saveSolicitud(string user_id, string proceso_id, string observaciones)
        {

            HttpClient client = new HttpClient();

            string URL1 = "http://asistententejudicial.com/save/solicitud";

            Solicitudes solicitud = new Solicitudes();
            solicitud.user_id = user_id;
            solicitud.proceso_id = proceso_id;
            solicitud.observaciones = observaciones;
           

            string json = JsonConvert.SerializeObject(solicitud);


            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //HttpResponseMessage response = await client.PostAsync(URL1, content).ConfigureAwait(false);
            //HttpResponseMessage response = client.PostAsync(URL1, content).Result;
            var response = await client.PostAsync(URL1, content);

            //var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);

            //return result;
        }
    }
}
