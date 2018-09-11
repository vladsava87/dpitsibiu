using DatabaseLayer.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp.Services
{
    public sealed class ObservatieService
    {
        private string WebSiteAPI = ConfigurationManager.AppSettings["RestAPI"];

        private static HttpClient _client;
        private static ObservatieService _instance;

        ObservatieService()
        {
            _client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
            );
        }

        public static ObservatieService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ObservatieService();
                }

                return _instance;
            }
        }

        public Task<List<ObservatieDTO>> GetListaObservatieAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Observatie";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    List<ObservatieDTO> observatieCautata = JsonConvert.DeserializeObject<List<ObservatieDTO>>(content);

                    return observatieCautata;
                }

                return null;
            });
          
        }

        
        public Task<ObservatieDTO> GetObservatieAsync(int _observatieID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Observatie/";

                var uri = new Uri(WebSiteAPI + requestLink + _observatieID.ToString());

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    ObservatieDTO observatieCautata = JsonConvert.DeserializeObject<ObservatieDTO>(content);

                    return observatieCautata;
                }
                return null;

            });
            
        
        }

        public Task<string> PostObservatieAsync(ObservatieDTO observatieNoua)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Observatie";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(observatieNoua);
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

        public Task<string> PutObservatieAsync(ObservatieDTO observatieNoua)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Observatie/";

                var uri = new Uri(WebSiteAPI + requestLink + observatieNoua.Id.ToString());

                var myContent = JsonConvert.SerializeObject(observatieNoua);
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

        public Task<string> DeleteObservatieAsync(int _observatieID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Observatie/";

                var uri = new Uri(WebSiteAPI + requestLink + _observatieID.ToString());

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
