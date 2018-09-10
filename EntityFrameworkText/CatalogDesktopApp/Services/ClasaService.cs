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
    public sealed class ClasaService
    {
        private const string WebSiteAPI = @"http://localhost:1208/api";

        private static HttpClient _client;
        private static ClasaService _instance;

        ClasaService()
        {
            _client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
            );
        }

        public static ClasaService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClasaService();
                }

                return _instance;
            }
        }

        public  Task<List<ClasaDTO>> GetListaClasaAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Clasa";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response =  _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    List<ClasaDTO> clasacautata = JsonConvert.DeserializeObject<List<ClasaDTO>>(content);

                    return clasacautata;
                }

                return null;
            });
           
        }

        public Task<ClasaDTO> GetClasaAsync(int _clasaID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Clasa/";

                var uri = new Uri(WebSiteAPI + requestLink + _clasaID.ToString());

                var response =  _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    ClasaDTO clasacautata = JsonConvert.DeserializeObject<ClasaDTO>(content);

                    return clasacautata;
                }

                return null;
            });
        }

        //    try
        //    {
        //        var requestLink = "/Clasa/";

        //        var uri = new Uri(WebSiteAPI + requestLink + _clasaID.ToString());

        //        var response = await _client.GetAsync(uri);
        //        if(response.IsSuccessStatusCode)
        //        {
        //            var content = await response.Content.ReadAsStringAsync();

        //            ClasaDTO clasacautata = JsonConvert.DeserializeObject<ClasaDTO>(content);

        //            return clasacautata;
        //        }
        //    }
        //    catch (Exception ex) { }
            
        //    return null;
        //}

        public Task<string> PostClasaAsync(ClasaDTO clasaModificata)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Clasa";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(clasaModificata);
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

        public Task<string> PutClasaAsync(ClasaDTO clasaModificat)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Clasa/";

                var uri = new Uri(WebSiteAPI + requestLink + clasaModificat.Id.ToString());

                var myContent = JsonConvert.SerializeObject(clasaModificat);
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

        public Task<string> DeleteClasaAsync(int _clasaID)
        {
            return Task.Factory.StartNew(() =>
            {
                var requestLink = "/Clasa/";

                var uri = new Uri(WebSiteAPI + requestLink + _clasaID.ToString());

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
