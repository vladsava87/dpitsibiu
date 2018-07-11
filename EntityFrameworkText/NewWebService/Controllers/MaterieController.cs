using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewWebService.Controllers
{
    public class MaterieController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Materie
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Materie/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Materie
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Materie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Materie/5
        public void Delete(int id)
        {
        }
    }
}
