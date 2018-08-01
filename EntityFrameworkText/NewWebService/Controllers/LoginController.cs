using DatabaseLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewWebService.Controllers
{
    public class LoginController : ApiController
    {
        public HttpResponseMessage CheckCredentials()
        {
            var msg = new HttpResponseMessage();

            try
            {
                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Login successful");
            }
            catch
            {
                msg.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                msg.Content = new StringContent("Unauthorized user, please check username or password");
            }

            return msg;
        }
    }
}
