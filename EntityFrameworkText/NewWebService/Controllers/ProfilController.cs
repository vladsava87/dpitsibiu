using DatabaseLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using DatabaseLayer.DTO;

namespace NewWebService.Controllers
{
    public class ProfilController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Profil
        public IEnumerable<ProfilDTO> Get()
        {
            var profile = catalog.Profiluri.ToList();

            var tProfile = Mapper.Map<List<ProfilDTO>>(profile);

            return tProfile;
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
