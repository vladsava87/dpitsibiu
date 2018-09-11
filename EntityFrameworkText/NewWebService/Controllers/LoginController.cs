using DatabaseLayer;
using DatabaseLayer.DataModels;
using Newtonsoft.Json;
using NewWebService.Util;
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
            var utilizator = new Utilizator();

            t_elev userelev = catalog.Elevi.Where(elevspecific => elevspecific.Email == username).FirstOrDefault();

            if(userelev == null)
            {
                t_profesor userprof = catalog.Profesorii.Where(profspecific => profspecific.Email == username).FirstOrDefault();

                if(userprof != null && userprof.Parola == password)
                {
                    utilizator.Tip = ut.profesor;
                    utilizator.Id = userprof.Id;

                    msg.Content = new StringContent(JsonConvert.SerializeObject(utilizator));
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
                    utilizator.Tip = ut.elev;
                    utilizator.Id = userelev.Id;

                    msg.Content = new StringContent(JsonConvert.SerializeObject(utilizator));
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
