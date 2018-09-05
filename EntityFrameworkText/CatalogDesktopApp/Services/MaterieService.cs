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

        public async Task<List<MaterieDTO>> GetListaMaterie()
        {
            try
            {
                var requestLink = "/Materie";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<MaterieDTO> materiecautata = JsonConvert.DeserializeObject<List<MaterieDTO>>(content);

                    return materiecautata;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<MaterieDTO> GetMaterie(int _materieID)
        {
            try
            {
                var requestLink = "/Materie/";

                var uri = new Uri(WebSiteAPI + requestLink + _materieID.ToString());

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    MaterieDTO materiecautata = JsonConvert.DeserializeObject<MaterieDTO>(content);

                    return materiecautata;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<string> PostMaterie(MaterieDTO materieNoua)
        {
            try
            {
                var requestLink = "/Materie";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(materieNoua);
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

        public async Task<string> PutMaterie(MaterieDTO materieNoua)
        {
            try
            {
                var requestLink = "/Materie/";

                var uri = new Uri(WebSiteAPI + requestLink + materieNoua.Id.ToString());

                var myContent = JsonConvert.SerializeObject(materieNoua);
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

        public async Task<string> DeleteMaterie(int _materieID)
        {
            try
            {
                var requestLink = "/Materie/";

                var uri = new Uri(WebSiteAPI + requestLink + _materieID.ToString());

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
