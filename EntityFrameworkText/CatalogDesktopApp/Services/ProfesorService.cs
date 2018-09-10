using DatabaseLayer.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp.Services
{
    public sealed class ProfesorService
    {
        private const string WebSiteAPI = @"http://localhost:1208/api";

        private static HttpClient _client;
        private static ProfesorService _instance;

        ProfesorService()
        {
            _client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
            );
        }

        public static ProfesorService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProfesorService();
                }

                return _instance;
            }
        }

        public Task<List<ProfesorDTO>> GetListaProfesorAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Profesor";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    List<ProfesorDTO> profesoriCautati = JsonConvert.DeserializeObject<List<ProfesorDTO>>(content);

                    return profesoriCautati;
                }

                return null;
            });
           
        }

       
        public Task<ProfesorDTO> GetProfesorAsync(int _profesorID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Profesor/";

                var uri = new Uri(WebSiteAPI + requestLink + _profesorID.ToString());

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    ProfesorDTO profesorCautat = JsonConvert.DeserializeObject<ProfesorDTO>(content);

                    return profesorCautat;
                }

                return null;
            });
        }

        public Task<string> PostProfesorAsync(ProfesorDTO profesorNou)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Profesor";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(profesorNou);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);

                var response = _client.PostAsync(uri, byteContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    return content;
                }

                return null;
            });
            
        }

        public Task<string> PutProfesorAsync(ProfesorDTO profesorNou)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Profesor/";

                var uri = new Uri(WebSiteAPI + requestLink + profesorNou.Id.ToString());

                var myContent = JsonConvert.SerializeObject(profesorNou);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);

                var response = _client.PutAsync(uri, byteContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    return content;
                }

                return null;
            });
           
        }

        public Task<string> DeleteProfesorAsync(int _profesorID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Profesor/";

                var uri = new Uri(WebSiteAPI + requestLink + _profesorID.ToString());

                var response = _client.DeleteAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    return content;
                }

                return null;
            });
            
        }
    }
}
