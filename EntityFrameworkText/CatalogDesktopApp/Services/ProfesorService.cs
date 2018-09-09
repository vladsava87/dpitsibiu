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

        public async Task<List<ProfesorDTO>> GetListaProfesor()
        {
            try
            {
                var requestLink = "/Profesor";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<ProfesorDTO> profesoriCautati = JsonConvert.DeserializeObject<List<ProfesorDTO>>(content);

                    return profesoriCautati;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public ProfesorDTO GetProfesor (int _profesorID)
        {
            return GetProfesorAsync(_profesorID).Result;
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

        public async Task<string> PostProfesor(ProfesorDTO profesorNou)
        {
            try
            {
                var requestLink = "/Profesor";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(profesorNou);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);

                var response = await _client.PostAsync(uri, byteContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return content;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<string> PutProfesor(ProfesorDTO profesorNou)
        {
            try
            {
                var requestLink = "/Profesor/";

                var uri = new Uri(WebSiteAPI + requestLink + profesorNou.Id.ToString());

                var myContent = JsonConvert.SerializeObject(profesorNou);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);

                var response = await _client.PutAsync(uri, byteContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return content;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<string> DeleteProfesor(int _profesorID)
        {
            try
            {
                var requestLink = "/Profesor/";

                var uri = new Uri(WebSiteAPI + requestLink + _profesorID.ToString());

                var response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return content;
                }
            }
            catch (Exception ex) { }

            return null;
        }
    }
}
