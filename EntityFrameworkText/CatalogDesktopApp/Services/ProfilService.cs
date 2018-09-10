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
    public sealed class ProfilService
    {
        private const string WebSiteAPI = @"http://localhost:1208/api";

        private static HttpClient _client;
        private static ProfilService _instance;

        ProfilService()
        {
            _client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
            );
        }

        public static ProfilService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProfilService();
                }

                return _instance;
            }
        }

        public Task<List<ProfilDTO>> GetListaProfilAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Profil";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    List<ProfilDTO> profiluriCautate = JsonConvert.DeserializeObject<List<ProfilDTO>>(content);

                    return profiluriCautate;
                }

                return null;
            });
           

           
        }

        public Task<ProfilDTO> GetProfilAsync(int _profilID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Profil/";

                var uri = new Uri(WebSiteAPI + requestLink + _profilID.ToString());

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    ProfilDTO profilCautat = JsonConvert.DeserializeObject<ProfilDTO>(content);

                    return profilCautat;
                }

                return null;
            });
        }

        public Task<string> PostProfilAsync(ProfilDTO profilNou)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Profil";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(profilNou);
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

        public Task<string> PutProfilAsync(ProfilDTO profilNou)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Profil/";

                var uri = new Uri(WebSiteAPI + requestLink + profilNou.Id.ToString());

                var myContent = JsonConvert.SerializeObject(profilNou);
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

        public Task<string> DeleteProfilAsync(int _profilID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Profil/";

                var uri = new Uri(WebSiteAPI + requestLink + _profilID.ToString());

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
