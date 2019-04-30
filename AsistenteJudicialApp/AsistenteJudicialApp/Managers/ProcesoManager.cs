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
    class ProcesoManager
    {

        HtClient htclient = new HtClient();

        public async Task<IEnumerable<Proceso>> getProcesos()
        {
            const String URL = "http://asistententejudicial.com/th4mxtads93iwkk393ko3mdjjeliekk4o3jeki33j3k/procesos";

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Proceso>>(content);

            }

            return Enumerable.Empty<Proceso>();
        }

        public async Task<IEnumerable<Proceso>> getProcesosUser(string id)
        {
            String URL = "http://asistententejudicial.com/th4mxtads93iwkk393ko3mdjjeliekk4o3jeki33j3k/procesos/" + id;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Proceso>>(content);

            }

            return Enumerable.Empty<Proceso>();
        }

        public async Task<Proceso> getProceso(int id)
        {
            String URL = "http://asistententejudicial.com/th4mxtads93iwkk393ko3mdjjeliekk4o3jeki33j3k/proceso/" + id;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Proceso>(content);

            }

            return null;
        }

        public async Task<Proceso> getProcesoRadicacion(string radicacion)
        {
            String URL = "http://asistententejudicial.com/th4mxtads93iwkk393ko3mdjjeliekk4o3jeki33j3k/find/proceso/" + radicacion;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Proceso>(content);

            }

            return null;
        }



        public async Task<IEnumerable<Estado>> getEstados(string id)
        {
            String URL = "http://asistententejudicial.com/th4mxtads93iwkk393ko3mdjjeliekk4o3jeki33j3k/estados/" + id;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Estado>>(content);

            }

            return Enumerable.Empty<Estado>();
        }

        public async void addProcesoUser(string id, string radicacion)
        {
            String URL = "http://asistententejudicial.com/th4mxtads93iwkk393ko3mdjjeliekk4o3jeki33j3k/save/proceso/" + radicacion + "/" + id;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(URL);

        }

        public async void detachProcesoUser(string user_id, string proceso_id)
        {
            String URL = "http://asistententejudicial.com/th4mxtads93iwkk393ko3mdjjeliekk4o3jeki33j3k/delete/proceso/" + user_id + "/" + proceso_id;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(URL);

        }

        public async void saveProceso(string radicacion,string demandante,string demandado, string juzgado)
        {

            HttpClient client = new HttpClient();

            string URL1 = "http://asistententejudicial.com/th4mxtads93iwkk393ko3mdjjeliekk4o3jeki33j3k/guardar";

            Proceso proceso = new Proceso();

            proceso.radicacion = radicacion;
            proceso.demandado = demandado;
            proceso.demandante = demandante;
            proceso.juzgado = juzgado;

            string json = JsonConvert.SerializeObject(proceso);


            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //HttpResponseMessage response = await client.PostAsync(URL1, content).ConfigureAwait(false);
            //HttpResponseMessage response = client.PostAsync(URL1, content).Result;
            var response = await client.PostAsync(URL1, content);

            //var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);

            //return result;
        }

        public async void saveProcesoUser(string radicacion, string juzgado,string id)
        {

            HttpClient client = new HttpClient();

            string URL1 = "http://asistententejudicial.com/th4mxtads93iwkk393ko3mdjjeliekk4o3jeki33j3k/guardar/" + id;

            

            Proceso proceso = new Proceso();

            proceso.radicacion = radicacion;            
            proceso.juzgado = juzgado;

            string json = JsonConvert.SerializeObject(proceso);


            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //HttpResponseMessage response = await client.PostAsync(URL1, content).ConfigureAwait(false);
            //HttpResponseMessage response = client.PostAsync(URL1, content).Result;
            var response = await client.PostAsync(URL1, content);

            //var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);

            //return result;
        }
    }
}
