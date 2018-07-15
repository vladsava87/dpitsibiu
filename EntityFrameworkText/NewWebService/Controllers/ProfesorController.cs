using AutoMapper;
using DatabaseLayer;
using DatabaseLayer.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NewWebService.Controllers
{
    public class ProfesorController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Profesor
        public IEnumerable<ProfesorDTO> Get()
        {
            var profesori = catalog.Profesorii.ToList();

            var tprofesori = Mapper.Map<List<ProfesorDTO>>(profesori);

            return tprofesori;
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
