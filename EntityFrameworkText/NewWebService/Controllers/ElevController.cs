using AutoMapper;
using DatabaseLayer;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace NewWebService.Controllers
{
    public class ElevController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Elev
        public IEnumerable<string> Get()
        {
            var elevi = catalog.Elevi.ToList();

            var televi = Mapper.Map<List<ElevDTO>>(elevi);

            return televi;
        }

        // GET: api/Elev/5
        public string Get(int id)
        {
            var elev = catalog.Elevi.Where(e => e.Id == id).FirstOrDefault();

            var telev = Mapper.Map<ElevDTO>(elev);

            return telev;
        }

        // POST: api/Elev
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                ElevDTO elev = JsonConvert.DeserializeObject<ElevDTO>(value);
                t_elev elevnou = Mapper.Map<ElevDTO, t_elev>(elev);

                catalog.Elevi.Add(elevnou);
                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("POST Request performed successfully");
            }
            catch (Exception e)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("POST Request could not be performed");
            }

            return msg;
        }

        // PUT: api/Elev/5
        public void Put(int id, [FromBody]string value)
        {
            var value = request.Content.ReadAsStringAsync().Result;

            t_elev Elev = catalog.Elevi.Where(e => e.Id == id).FirstOrDefault();
            ElevDTO elevnou = JsonConvert.DeserializeObject<ElevDTO>(value);
           
            Elev.Id = elevnou.Id;
            Elev.Nume = elevnou.Nume;
            Elev.Prenume = elevnou.Prenume;
            Elev.DataNastere = elevnou.DataNestere;
            Elev.Telefon = elevnou.Telefon;
            Elev.Email = elevnou.Email;
            Elev.NumarMatricol = elevnou.NumarMatricol;
            Elev.Clasa = elevnou.Clasa;
            
            t_nota Nota = catalog.Note.Where(n => n.Id == elevnou.Id).FirstOrDefault();
            Elev.Nota = Nota;
            
            t_elev Absenta = catalog.Absente.Where(a => a.Id == elevnou.Id).FirstOrDefault();
            Elev.Absenta = Absenta;

            t_elev Observatie = catalog.Observatii.Where(o => o.Id == elevnou.Id).FirstOrDefault();
            Elev.Observatie = Observatie;
        }

        // DELETE: api/Elev/5
        public void Delete(int id)
        {
            t_elev Elev = catalog.Elevi.Where(e => e.Id == id).FirstOrDefault();
            catalog.Elevi.Remove(Elev);
            catalog.SaveChanges();
        }
    }
}
