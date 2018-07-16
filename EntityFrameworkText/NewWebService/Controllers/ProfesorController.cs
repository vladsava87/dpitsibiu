﻿using AutoMapper;
using DatabaseLayer;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;
using Newtonsoft.Json;
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
        public ProfesorDTO Get(int id)
        {
            var profesor = catalog.Profesorii.Where(profesorul => profesorul.Id == id).FirstOrDefault();

            var tprofesor = Mapper.Map<ProfesorDTO>(profesor);

            return tprofesor;
        }

        // POST: api/Profesor
        public void Post([FromBody]string value)
        {
            ProfesorDTO profesor = JsonConvert.DeserializeObject<ProfesorDTO>(value);
            t_profesor profnou = Mapper.Map<ProfesorDTO, t_profesor>(profesor);

            catalog.Profesorii.Add(profnou);
            catalog.SaveChanges();
        }

        // PUT: api/Profesor/5
        public void Put(int id, [FromBody]string value)
        {
            t_profesor profesor = catalog.Profesorii.Where(prof => prof.Id == id).FirstOrDefault();
            ProfesorDTO profesornou = JsonConvert.DeserializeObject<ProfesorDTO>(value);

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
