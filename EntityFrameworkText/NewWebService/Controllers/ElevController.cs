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
        public IEnumerable<ElevDTO> Get()
        {
            var elevi = catalog.Elevi.ToList();

            var televi = Mapper.Map<List<ElevDTO>>(elevi);

            return televi;
        }

        // GET: api/Elev/5
        public ElevDTO Get(int id)
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
            catch (Exception)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("POST Request could not be performed");
            }

            return msg;
        }

        // PUT: api/Elev/5
        public void Put(int id, HttpRequestMessage request)
        {
            var value = request.Content.ReadAsStringAsync().Result;

            ElevDTO elevnou = JsonConvert.DeserializeObject<ElevDTO>(value);
            t_elev elev = catalog.Elevi.Where(e => e.Id == id).FirstOrDefault();

            elev.Id = elevnou.Id;
            elev.Nume = elevnou.Nume;
            elev.Prenume = elevnou.Prenume;
            elev.Data = elevnou.Data;
            elev.Telefon = elevnou.Telefon;
            elev.Email = elevnou.Email;
            elev.Numar_Matricol = elevnou.Numar_Matricol;
            elev.ClasaID = elevnou.ClasaID;

            //t_clasa clasa = catalog.Clase.Where(c => c.Id == elevnou.Id).FirstOrDefault();
            //elev.Clasa = clasa;
            
            //t_nota Nota = catalog.Note.Where(n => n.Id == elevnou.Id).FirstOrDefault();
            //Elev.Nota = Nota;

            //t_elev Absenta = catalog.Absente.Where(a => a.Id == elevnou.Id).FirstOrDefault();
            //Elev.Absenta = Absenta;

            //t_elev Observatie = catalog.Observatii.Where(o => o.Id == elevnou.Id).FirstOrDefault();
            //Elev.Observatie = Observatie;

            catalog.SaveChanges();
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
