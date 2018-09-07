﻿using DatabaseLayer.DTO;
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

        public async Task<List<ClasaDTO>> GetListaClasa()
        {
            try
            {
                var requestLink = "/Clasa";

                var uri = new Uri(WebSiteAPI + requestLink);

                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<ClasaDTO> clasacautata = JsonConvert.DeserializeObject<List<ClasaDTO>>(content);

                    return clasacautata;
                }
            }
            catch (Exception ex) { }

            return null;
        }


        public ClasaDTO GetClasa(int _clasaID)
        {
            return GetClasaAsync(_clasaID).Result;
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

        public async Task<string> PostClasa(ClasaDTO clasaModificata)
        {
            try
            {
                var requestLink = "/Clasa";

                var uri = new Uri(WebSiteAPI + requestLink);

                var myContent = JsonConvert.SerializeObject(clasaModificata);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);

                var response = await _client.PostAsync(uri, byteContent);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return content;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<string> PutClasa(ClasaDTO clasaModificat)
        {
            try
            {
                var requestLink = "/Clasa/";

                var uri = new Uri(WebSiteAPI + requestLink + clasaModificat.Id.ToString());

                var myContent = JsonConvert.SerializeObject(clasaModificat);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);

                var response = await _client.PutAsync(uri, byteContent);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return content;
                }
            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<string> DeleteClasa(int _clasaID)
        {
            try
            {
                var requestLink = "/Clasa/";

                var uri = new Uri(WebSiteAPI + requestLink + _clasaID.ToString());

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
