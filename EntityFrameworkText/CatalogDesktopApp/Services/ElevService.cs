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
    public sealed class ElevService
    {
        private const string WebSiteAPI = @"http://localhost:1208/api";

        private static HttpClient _client;
        private static ElevService _instance;

        ElevService()
        {
            _client = new HttpClient();

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
            );
        }

        public static ElevService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ElevService();
                }

                return _instance;
            }
        }

        public async Task<List<ElevDTO>> GetListaElev()
        {
            try
            {
                var requestLink = "/Elev";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = await _client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<ElevDTO> eleviAfisati = JsonConvert.DeserializeObject<List<ElevDTO>>(content);

                    return eleviAfisati;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<ElevDTO> GetElev(int _elevID)
        {
            try
            {
                var requestLink = "/Elev/";

                var uri = new Uri(WebSiteAPI + requestLink + _elevID.ToString());

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    ElevDTO elevAfisat = JsonConvert.DeserializeObject<ElevDTO>(content);

                    return elevAfisat;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public Task<ElevDTO> GetElevAsync(int _elevID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Elev/";

                var uri = new Uri(WebSiteAPI + requestLink + _elevID.ToString());

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    ElevDTO elevAfisat = JsonConvert.DeserializeObject<ElevDTO>(content);

                    return elevAfisat;
                }

                return null;
            });
        }

        public async Task<string> PostElev(ElevDTO elevNou)
        {
            try
            {
                var requestLink = "/Elev";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(elevNou);
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

        public async Task<string> PutElev(ElevDTO elevNou)
        {
            try
            {
                var requestLink = "/Elev/";

                var uri = new Uri(WebSiteAPI + requestLink + elevNou.Id.ToString());

                var myContent = JsonConvert.SerializeObject(elevNou);
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

        public async Task<string> DeleteElev(int _elevID)
        {
            try
            {
                var requestLink = "/Elev/";

                var uri = new Uri(WebSiteAPI + requestLink + _elevID.ToString());

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
