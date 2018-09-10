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
    public sealed class MaterieService
    {
        private const string WebSiteAPI = @"http://localhost:1208/api";

        private static HttpClient _client;
        private static MaterieService _instance;

        MaterieService()
        {
            _client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
            );
        }

        public static MaterieService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MaterieService();
                }

                return _instance;
            }
        }

        public Task<List<MaterieDTO>> GetListaMaterieAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Materie";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    List<MaterieDTO> materiecautata = JsonConvert.DeserializeObject<List<MaterieDTO>>(content);

                    return materiecautata;
                }

                return null;
            });
            
        }

       
        public Task<MaterieDTO> GetMaterieAsync(int _materieID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Materie/";

                var uri = new Uri(WebSiteAPI + requestLink + _materieID.ToString());

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    MaterieDTO materiecautata = JsonConvert.DeserializeObject<MaterieDTO>(content);

                    return materiecautata;
                }

                return null;
            });
        }

        public Task<string> PostMaterieAsync(MaterieDTO materieNoua)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Materie";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(materieNoua);
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

        public Task<string> PutMaterieAsync(MaterieDTO materieNoua)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Materie/";

                var uri = new Uri(WebSiteAPI + requestLink + materieNoua.Id.ToString());

                var myContent = JsonConvert.SerializeObject(materieNoua);
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

        public Task<string> DeleteMaterieAsync(int _materieID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Materie/";

                var uri = new Uri(WebSiteAPI + requestLink + _materieID.ToString());

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
