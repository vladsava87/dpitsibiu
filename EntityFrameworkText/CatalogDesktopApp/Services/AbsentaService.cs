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
    public sealed class AbsentaService
    {
        private const string WebSiteAPI = @"http://localhost:1208/api";

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

        public async Task<List<AbsentaDTO>> GetListaAbsenta()
        {
            try
            {
                var requestLink = "/Absenta";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<AbsentaDTO> absentaCautata = JsonConvert.DeserializeObject<List<AbsentaDTO>>(content);

                    return absentaCautata;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<AbsentaDTO> GetAbsenta(int _absentaID)
        {
            try
            {
                var requestLink = "/Absenta/";

                var uri = new Uri(WebSiteAPI + requestLink + _absentaID.ToString());

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    AbsentaDTO absentaCautata = JsonConvert.DeserializeObject<AbsentaDTO>(content);

                    return absentaCautata;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<string> PostAbsenta(AbsentaDTO absentaNoua)
        {
            try
            {
                var requestLink = "/Absenta";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(absentaNoua);
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

        public async Task<string> PutAbsenta(AbsentaDTO absentaNoua)
        {
            try
            {
                var requestLink = "/Absenta/";

                var uri = new Uri(WebSiteAPI + requestLink + absentaNoua.Id.ToString());

                var myContent = JsonConvert.SerializeObject(absentaNoua);
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

        public async Task<string> DeleteAbsenta(int _absentaID)
        {
            try
            {
                var requestLink = "/Absenta/";

                var uri = new Uri(WebSiteAPI + requestLink + _absentaID.ToString());

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
