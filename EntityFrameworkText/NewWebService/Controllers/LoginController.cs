using DatabaseLayer;
using DatabaseLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace NewWebService.Controllers
{
    public class LoginController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        public HttpResponseMessage CheckCredentials(HttpRequestMessage credentials)
        {
            var msg = new HttpResponseMessage();

            string userpass = credentials.Content.ReadAsStringAsync().Result;
            string[] usernamePasswordArray = userpass.Split(':');
            string username = usernamePasswordArray[0];
            string password = usernamePasswordArray[1];

            t_elev userelev = catalog.Elevi.Where(elevspecific => elevspecific.Email == username).FirstOrDefault();

            if(userelev == null)
            {
                t_profesor userprof = catalog.Profesorii.Where(profspecific => profspecific.Email == username).FirstOrDefault();

                if(userprof != null && userprof.Parola == password)
                {
                    string token = "1A1C0E0M0N0O1P0P";
                    msg.StatusCode = HttpStatusCode.OK;
                    msg.Content = new StringContent("Login successful. Your token is " + token);
                }
                else
                {
                    msg.StatusCode = HttpStatusCode.Unauthorized;
                    msg.Content = new StringContent("Access denied");
                }
            }
            else
            {
                if(userelev.Parola == password)
                {
                    string token = "0A0C0E0M0N0O0P0P";
                    msg.StatusCode = HttpStatusCode.OK;
                    msg.Content = new StringContent("Login successful. Your token is " + token);
                }
                else
                {
                    msg.StatusCode = HttpStatusCode.Unauthorized;
                    msg.Content = new StringContent("Access denied");
                }
            }

            return msg;
        }
    }
}
