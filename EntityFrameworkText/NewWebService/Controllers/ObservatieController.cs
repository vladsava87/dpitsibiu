using AutoMapper;
using DatabaseLayer;
using DatabaseLayer.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NewWebService.Controllers
{
    public class ObservatieController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();
        
        // GET api/values
        public IEnumerable<ObservatieDTO> Get()
        {
            var obs = catalog.Observatii.ToList();

            var tObs = Mapper.Map<List<ObservatieDTO>>(obs);

            return tObs;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
