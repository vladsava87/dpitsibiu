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
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
