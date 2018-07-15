using AutoMapper;
using DatabaseLayer;
using DatabaseLayer.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NewWebService.Controllers
{
    public class ClasaController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Clasa
        public IEnumerable<ClasaDTO> Get()
        {
            var clase = catalog.Elevi.ToList();

            var tclase = Mapper.Map<List<ClasaDTO>>(clase);

            return tclase;
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
