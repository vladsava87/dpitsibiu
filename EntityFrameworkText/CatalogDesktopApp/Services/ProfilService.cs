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

        public async Task<List<ProfilDTO>> GetListaProfil()
        {
            try
            {
                var requestLink = "/Profil";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<ProfilDTO> profiluriCautate = JsonConvert.DeserializeObject<List<ProfilDTO>>(content);

                    return profiluriCautate;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<ProfilDTO> GetProfil(int _profilID)
        {
            try
            {
                var requestLink = "/Profil/";

                var uri = new Uri(WebSiteAPI + requestLink + _profilID.ToString());

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    ProfilDTO profilCautat = JsonConvert.DeserializeObject<ProfilDTO>(content);

                    return profilCautat;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<string> PostProfil(ProfilDTO profilNou)
        {
            try
            {
                var requestLink = "/Profil";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(profilNou);
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

        public async Task<string> PutProfil(ProfilDTO profilNou)
        {
            try
            {
                var requestLink = "/Profil/";

                var uri = new Uri(WebSiteAPI + requestLink + profilNou.Id.ToString());

                var myContent = JsonConvert.SerializeObject(profilNou);
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

        public async Task<string> DeleteProfil(int _profilID)
        {
            try
            {
                var requestLink = "/Profil/";

                var uri = new Uri(WebSiteAPI + requestLink + _profilID.ToString());

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
