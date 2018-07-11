using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ElevController : ApiController
    {
        // GET: api/Elev
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Elev/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Elev
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Elev/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Elev/5
        public void Delete(int id)
        {
        }
    }
}
