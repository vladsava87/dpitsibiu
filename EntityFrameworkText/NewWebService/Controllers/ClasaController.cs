using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewWebService.Controllers
{
    public class ClasaController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Clasa
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Clasa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clasa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clasa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clasa/5
        public void Delete(int id)
        {
        }
    }
}
