using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CatalogDesktopApp.Services
{
    public sealed class UserService
    {
        private const string WebSiteAPI = @"http://localhost:4545/api";

        private static HttpClient _client;
        private static UserService _instance;

        UserService()
        {
            _client = new HttpClient();

            //client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
            );
        }

        public static UserService Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new UserService();
                }

                return _instance;
            }
        }

        public async Task<string> PerformLogin(string username, string password)
        {
            try
            {
                var loginFunction = "/Login";
                
                var uri = new Uri(WebSiteAPI + loginFunction);

                var myContent = username + ":" + password;
              
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                var response = await _client.PostAsync(uri, byteContent);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        return content;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
    }
}
