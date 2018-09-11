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
    public sealed class NotaService
    {
        private string WebSiteAPI = ConfigurationManager.AppSettings["RestAPI"];

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

        public static NotaService Instance
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

        public Task<List<NotaDTO>> GetListaNotaAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Nota";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    List<NotaDTO> noteCautate = JsonConvert.DeserializeObject<List<NotaDTO>>(content);

                    return noteCautate;
                }

                return null;
            });
          
        }

        public Task<NotaDTO> GetNotaAsync(int _notaID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Nota/";

                var uri = new Uri(WebSiteAPI + requestLink + _notaID.ToString());

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    NotaDTO notaCautata = JsonConvert.DeserializeObject<NotaDTO>(content);

                    return notaCautata;
                }

                return null;
            });
            }
        

        public Task<string> PostNotaAsync(NotaDTO notaNoua)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Nota";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(notaNoua);
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

        public Task<string> PutNotaAsync(NotaDTO notaNoua)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Nota/";

                var uri = new Uri(WebSiteAPI + requestLink + notaNoua.Id.ToString());

                var myContent = JsonConvert.SerializeObject(notaNoua);
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

        public Task<string> DeleteNotaAsync(int _notaID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Nota/";

                var uri = new Uri(WebSiteAPI + requestLink + _notaID.ToString());

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
