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
    [BasicAuthentication]
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
        public ProfesorDTO Get(int id)
        {
            var profesor = catalog.Profesorii.Where(profesorul => profesorul.Id == id).FirstOrDefault();

            var tprofesor = Mapper.Map<ProfesorDTO>(profesor);

            return tprofesor;
        }

        // POST: api/Profesor
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                ProfesorDTO profesor = JsonConvert.DeserializeObject<ProfesorDTO>(value);
                t_profesor profnou = Mapper.Map<ProfesorDTO, t_profesor>(profesor);

                catalog.Profesorii.Add(profnou);
                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Un profesor nou a fost adaugat!");
            }
            catch(Exception)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Nu s-a putut adauga un profesor nou!");
            }

            return msg;
        }

        // PUT: api/Profesor/5
        public HttpResponseMessage Put(int id, HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                t_profesor prof = catalog.Profesorii.Where(profcautat => profcautat.Id == id).FirstOrDefault();
                ProfesorDTO profnou = JsonConvert.DeserializeObject<ProfesorDTO>(value);

                prof.Id = profnou.Id;
                prof.Email = profnou.Email;
                prof.Nume = profnou.Nume;
                prof.Parola = profnou.Parola;
                prof.Prenume = profnou.Prenume;
                prof.Telefon = profnou.Telefon;
                
                //Lista de Note
                //Lista de Observatii
                //Lista de Absente
                //ICollection de Materii

                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Modificarile au fost procesate cu succes!");
            }
            catch (Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Nu s-au putut executa modificarile dorite!");
            }

            return msg;
        }

        // DELETE: api/Profesor/5
        public HttpResponseMessage Delete(int id)
        {
            var msg = new HttpResponseMessage();

            try
            {
                t_profesor prof = catalog.Profesorii.Where(profcautat => profcautat.Id == id).FirstOrDefault();
                catalog.Profesorii.Remove(prof);

                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Stergerea a fost executata cu succes!");
            }
            catch (Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Profesorul dorit nu a putut fi sters!");
            }

            return msg;
        }
    }
}
