using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProfesorController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Profesor
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Profesor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Profesor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Profesor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Profesor/5
        public void Delete(int id)
        {
        }
    }
}
