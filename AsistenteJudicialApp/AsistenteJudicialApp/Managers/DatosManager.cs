using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using AsistenteJudicialApp.Models;
using System.Threading.Tasks;

namespace AsistenteJudicialApp.Managers
{
    class DatosManager
    {
        HtClient htclient = new HtClient();

        public async Task<Userdato> getDatos(int id)
        {
            String URL = "http://asistententejudicial.com/datos/user/" + id;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Userdato>(content);
            }

            return null;
        }

        public async void saveDatos(int id, string identificacion, string telefono,string direccion)
        {
            string URL = "http://asistententejudicial.com/";

            HttpClient client = new HttpClient();

            Userdato user = new Userdato();           
            user.identificacion = identificacion;
            user.telefono = telefono;
            user.direccion = direccion;
            user.user_id = id;
                        
            string json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(URL, content);
        }

        public async void updateDatos(int id, string identificacion, string telefono, string direccion)
        {
            string URL = "http://asistententejudicial.com/update/datos/" + id;

            HttpClient client = new HttpClient();

            Userdato userdato = new Userdato();            
            userdato.identificacion = identificacion;
            userdato.telefono = telefono;
            userdato.direccion = direccion;

            string json = JsonConvert.SerializeObject(userdato);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(URL, content);
        }
    }
}
