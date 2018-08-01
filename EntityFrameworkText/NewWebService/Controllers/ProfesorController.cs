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
                msg.Content = new StringContent("POST Request performed successfully");
            }
            catch(Exception e)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("POST Request could not be performed");
            }

            return msg;
        }

        // PUT: api/Profesor/5
        public void Put(int id, HttpRequestMessage request)
        {
            var value = request.Content.ReadAsStringAsync().Result;

            ProfesorDTO profesornou = JsonConvert.DeserializeObject<ProfesorDTO>(value);
            t_profesor profesor = catalog.Profesorii.Where(prof => prof.Id == id).FirstOrDefault();

            profesor.Id = profesornou.Id;
            profesor.Nume = profesornou.Nume;
            profesor.Prenume = profesornou.Prenume;
            profesor.Telefon = profesornou.Telefon;
            profesor.Email = profesornou.Email;

            //Lista de absente
            //Lista de materii
            //Lista de observatii

            catalog.SaveChanges();
        }

        // DELETE: api/Profesor/5
        public void Delete(int id)
        {
            t_profesor profesor = catalog.Profesorii.Where(prof => prof.Id == id).FirstOrDefault();
            catalog.Profesorii.Remove(profesor);

            catalog.SaveChanges();
        }
    }
}
