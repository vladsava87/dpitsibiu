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
    public sealed class NotaService
    {
        private const string WebSiteAPI = @"http://localhost:1208/api";

        private static HttpClient _client;
        private static NotaService _instance;

        NotaService()
        {
            _client = new HttpClient();

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
            );
        }

        private static NotaService Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new NotaService();
                }

                return _instance;
            }
        }

        public async Task<List<NotaDTO>> GetListaNota()
        {
            try
            {
                var requestLink = "/Nota";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = await _client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<NotaDTO> noteCautate = JsonConvert.DeserializeObject<List<NotaDTO>>(content);

                    return noteCautate;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<NotaDTO> GetNota(int _notaID)
        {
            try
            {
                var requestLink = "/Nota/";

                var uri = new Uri(WebSiteAPI + requestLink + _notaID.ToString());

                var response = await _client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    NotaDTO notaCautata = JsonConvert.DeserializeObject<NotaDTO>(content);

                    return notaCautata;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<string> PostNota(NotaDTO notaNoua)
        {
            try
            {
                var requestLink = "/Nota";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(notaNoua);
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

        public async Task<string> PutNota(NotaDTO notaNoua)
        {
            try
            {
                var requestLink = "/Nota/";

                var uri = new Uri(WebSiteAPI + requestLink + notaNoua.Id.ToString());

                var myContent = JsonConvert.SerializeObject(notaNoua);
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

        public async Task<string> DeleteNota(int _notaID)
        {
            try
            {
                var requestLink = "/Nota/";

                var uri = new Uri(WebSiteAPI + requestLink + _notaID.ToString());

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
