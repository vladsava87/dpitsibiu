using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProfilController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Profil
        public IEnumerable<string> Get()
        { var Profil = catalog.Profil.ToList();

          var tprofil = Mapper.Map<List<PtofilDTO>>(Profil);

            return tprofil;
        }

    // GET: api/Profil/5
    public string Get(int id)
        {
            return "value";
        }

        // POST: api/Profil
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Profil/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Profil/5
        public void Delete(int id)
        {
        }
    }
}
