<<<<<<< Updated upstream
﻿using AutoMapper;
using DatabaseLayer;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
=======
﻿using DatabaseLayer;
using DatabaseLayer.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using DatabaseLayer.DataModels;
>>>>>>> Stashed changes

namespace NewWebService.Controllers
{
    public class ElevController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

<<<<<<< Updated upstream
        // GET: api/Elev
        public IEnumerable<ElevDTO> Get()
        {
            var elevi = catalog.Elevi.ToList();

            var televi = Mapper.Map<List<ElevDTO>>(elevi);
=======
        public IEnumerable<ElevDTO> Get()
        {
            var Elevi = catalog.Elevi.ToList();

            var televi = Mapper.Map<List<ElevDTO>>(Elevi);
>>>>>>> Stashed changes

            return televi;
        }

        // GET: api/Elev/5
        public ElevDTO Get(int id)
        {
<<<<<<< Updated upstream
            var elev = catalog.Elevi.Where(e => e.Id == id).FirstOrDefault();
=======
            var elev = catalog.Elevi.Where(elevul => elevul.Id == id).FirstOrDefault();
>>>>>>> Stashed changes

            var telev = Mapper.Map<ElevDTO>(elev);

            return telev;
<<<<<<< Updated upstream
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
=======

        }

        // POST: api/Elev
        public void Post([FromBody]string value)
        {
            ElevDTO Elev = JsonConvert.DeserializeObject<ElevDTO>(value);

            var elevnou = Mapper.Map<ElevDTO, t_elev>(Elev);

            catalog.Elevi.Add(elevnou);
            catalog.SaveChanges();
        }

        // PUT: api/Elev/5
        public void Put(int id, [FromBody]string value)
        {
            var elev = catalog.Elevi.Where(elevul => elevul.Id == id).FirstOrDefault();
            ElevDTO Elev_schimbat = JsonConvert.DeserializeObject<ElevDTO>(value);
            elev.Id = Elev_schimbat.Id;
            elev.Nume = Elev_schimbat.Nume;
            elev.Prenume = Elev_schimbat.Prenume;
            elev.Data_nastere = Elev_schimbat.Data_nastere;
            elev.Telefon = Elev_schimbat.Telefon;
            elev.Email = Elev_schimbat.Email;
            elev.Numar_Matricol = Elev_schimbat.Numar_matricol;
            elev.ClasaID = Elev_schimbat.ClasaID;
            //elev.Clasa = Elev_schimbat.Clasa;
            //elev.Note = Elev_schimbat.Note;
            //elev.Absente = Elev_schimbat.Absente;
            //elev.Observatii = Elev_schimbat.Observatii;

            catalog.SaveChanges();

>>>>>>> Stashed changes
        }

        // DELETE: api/Elev/5
        public void Delete(int id)
<<<<<<< Updated upstream
        {
            t_elev Elev = catalog.Elevi.Where(e => e.Id == id).FirstOrDefault();
            catalog.Elevi.Remove(Elev);
            catalog.SaveChanges();
        }
    }
}
=======
        {
            t_elev elev = catalog.Elevi.Where(elevi => elevi.Id == id).FirstOrDefault();
            catalog.Elevi.Remove(elev);

            catalog.SaveChanges();
        }
    }
}

>>>>>>> Stashed changes
