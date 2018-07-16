using AutoMapper;
using DatabaseLayer;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;
using Newtonsoft.Json;
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
        public ClasaDTO Get(int id)
        {
            var clasa = catalog.Elevi.Where(elev => elev.Id == id).FirstOrDefault();

            var tclasa = Mapper.Map<ClasaDTO>(clasa);

            return tclasa;
        }

        // POST: api/Clasa
        public void Post([FromBody]string value)
        {
            ClasaDTO clasa = JsonConvert.DeserializeObject<ClasaDTO>(value);
            t_clasa clasanoua = Mapper.Map<ClasaDTO, t_clasa>(clasa);

            catalog.Clase.Add(clasanoua);
            catalog.SaveChanges();
        }

        // PUT: api/Clasa/5
        public void Put(int id, [FromBody]string value)
        {
            t_clasa clasa = catalog.Clase.Where(clasacautata => clasacautata.Id == id).FirstOrDefault();
            ClasaDTO clasanoua = JsonConvert.DeserializeObject<ClasaDTO>(value);

            clasa.Id = clasanoua.Id;
            clasa.Numar = clasanoua.Numar;
            clasa.Serie = clasanoua.Serie;
            clasa.An = clasanoua.An;

            t_profil profil = catalog.Profiluri.Where(profilcautat => profilcautat.Id == clasanoua.ProfilID).FirstOrDefault();
            clasa.Profil = profil;
            t_profesor diriginte = catalog.Profesorii.Where(dirig => dirig.Id == clasanoua.DiriginteID).FirstOrDefault();
            clasa.Diriginte = diriginte;
            //Lista de elevi

            catalog.SaveChanges();
        }

        // DELETE: api/Clasa/5
        public void Delete(int id)
        {
            t_clasa clasa = catalog.Clase.Where(clasacautata => clasacautata.Id == id).FirstOrDefault();
            catalog.Clase.Remove(clasa);

            catalog.SaveChanges();
        }
    }
}
