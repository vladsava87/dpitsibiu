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
    public sealed class AbsentaService
    {
        private string WebSiteAPI = ConfigurationManager.AppSettings["RestAPI"];

        private static HttpClient _client;
        private static AbsentaService _instance;

        AbsentaService()
        {
            _client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
            );
        }

        public static AbsentaService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AbsentaService();
                }

                return _instance;
            }
        }

        public Task<List<AbsentaDTO>> GetListaAbsentaAsync(int id)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Absenta/";

                var uri = new Uri(WebSiteAPI + requestLink + id);

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    List<AbsentaDTO> absentaCautata = JsonConvert.DeserializeObject<List<AbsentaDTO>>(content);

                    return absentaCautata;
                }

                return null;
            });
           
        }
        
    public Task<AbsentaDTO> GetAbsentaAsync(int _absentaID)
    {
        return Task.Factory.StartNew(() =>
            {
            var requestLink = "/Absenta/";

            var uri = new Uri(WebSiteAPI + requestLink + _absentaID.ToString());

            var response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                AbsentaDTO absentaCautata = JsonConvert.DeserializeObject<AbsentaDTO>(content);

                return absentaCautata;
            }   
            
            return null;
        });
    }

        public Task<string> PostAbsentaAsync(AbsentaDTO absentaNoua)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Absenta";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(absentaNoua);
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

        public Task<string> PutAbsentaAsync(AbsentaDTO absentaNoua)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Absenta/";

                var uri = new Uri(WebSiteAPI + requestLink + absentaNoua.Id.ToString());

                var myContent = JsonConvert.SerializeObject(absentaNoua);
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

        public Task<string> DeleteAbsentaAsync(int _absentaID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Absenta/";

                var uri = new Uri(WebSiteAPI + requestLink + _absentaID.ToString());

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
