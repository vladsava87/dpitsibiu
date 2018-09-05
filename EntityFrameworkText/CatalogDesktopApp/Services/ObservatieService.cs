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
    public sealed class ObservatieService
    {
        private const string WebSiteAPI = @"http://localhost:1208/api";

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

        public async Task<List<ObservatieDTO>> GetListaObservatie()
        {
            try
            {
                var requestLink = "/Observatie";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<ObservatieDTO> observatieCautata = JsonConvert.DeserializeObject<List<ObservatieDTO>>(content);

                    return observatieCautata;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<ObservatieDTO> GetObservatie(int _observatieID)
        {
            try
            {
                var requestLink = "/Observatie/";

                var uri = new Uri(WebSiteAPI + requestLink + _observatieID.ToString());

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    ObservatieDTO observatieCautata = JsonConvert.DeserializeObject<ObservatieDTO>(content);

                    return observatieCautata;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<string> PostObservatie(ObservatieDTO observatieNoua)
        {
            try
            {
                var requestLink = "/Observatie";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(observatieNoua);
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

        public async Task<string> PutObservatie(ObservatieDTO observatieNoua)
        {
            try
            {
                var requestLink = "/Observatie/";

                var uri = new Uri(WebSiteAPI + requestLink + observatieNoua.Id.ToString());

                var myContent = JsonConvert.SerializeObject(observatieNoua);
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

        public async Task<string> DeleteObservatie(int _observatieID)
        {
            try
            {
                var requestLink = "/Observatie/";

                var uri = new Uri(WebSiteAPI + requestLink + _observatieID.ToString());

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
