using DatabaseLayer.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp.Services
{
    public sealed class ClasaService
    {
        private const string WebSiteAPI = @"http://localhost:1208/api";

        private static HttpClient _client;
        private static ClasaService _instance;

        ClasaService()
        {
            _client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
            );
        }

        public static ClasaService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClasaService();
                }

                return _instance;
            }
        }
        
        public async Task<ClasaDTO> GetDetailsClasa(int clasaID)
        {
            try
            {
                var requestLink = "/Clasa/";

                var uri = new Uri(WebSiteAPI + requestLink + clasaID.ToString());

                var response = await _client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    ClasaDTO clasacautata = JsonConvert.DeserializeObject<ClasaDTO>(content);

                    return clasacautata;
                }
            }
            catch (Exception ex) { }
            
            return null;
        }

        public async Task<string> PostClasa(ElevDTO clasaModificata)
        {
            try
            {
                var requestLink = "/Clasa/";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(clasaModificata);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);

                var response = await _client.PostAsync(uri, byteContent);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return content;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<string> PutClasa(ElevDTO clasaModificat)
        {
            try
            {
                var requestLink = "/Clasa/";

                var uri = new Uri(WebSiteAPI + requestLink + clasaModificat.Id);

                var myContent = JsonConvert.SerializeObject(clasaModificat);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);

                var response = await _client.PutAsync(uri, byteContent);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return content;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<string> DeleteClasa(int _clasaID)
        {
            try
            {
                var requestLink = "/Clasa/";

                var uri = new Uri(WebSiteAPI + requestLink + _clasaID);

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
