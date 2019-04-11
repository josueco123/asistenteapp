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
            String UT = "http://asistententejudicial.com/log/" + email + "/" + password;

            HttpClient client = htclient.getCliente();          

            var res = await client.GetAsync(UT);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);
            }

            return null;
        }

        public async Task<User> getUser(int id)
        {
            String UT = "http://asistententejudicial.com/users/" + id;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(UT);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);

            }

            return null;
        }

        public async Task<Userestado> getUserEstado(string id)
        {
            String UT = "http://asistententejudicial.com/userestado/" + id;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(UT);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Userestado>(content);
            }
            return null;
        }
        public async void saveUser(string nombre,string correo,string clave)
        {
            string URL = "http://asistententejudicial.com/save/user";

            HttpClient client = new HttpClient();

            User user = new User();
            user.name = nombre;
            user.email = correo;
            user.password = clave;
            
            string json = JsonConvert.SerializeObject(user);


            var content = new StringContent(json, Encoding.UTF8, "application/json");            
            
            var response = await client.PostAsync(URL, content);
        }

        public async void updateUser(int id,string nombre, string correo)
        {
            string URL = "http://asistententejudicial.com/update/user/" + id;

            HttpClient client = new HttpClient();

            User user = new User();
            user.id = id;
            user.name = nombre;
            user.email = correo;                        

            string json = JsonConvert.SerializeObject(user);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(URL, content);
        }

        public async void changePass(string email)
        {
            String URL = "http://asistententejudicial.com/send/pass/" + email;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(URL);
        }

        public async void infoPagos(string id, string num)
        {
            String URL = "http://asistententejudicial.com/pago/" + id + "/"+ num;

            HttpClient client = htclient.getCliente();

            var res = await client.GetAsync(URL);
        }
       
    }
}
