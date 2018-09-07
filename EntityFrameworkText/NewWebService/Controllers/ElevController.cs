
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
                msg.Content = new StringContent("Un elev nou a fost adaugat!");
            }
            catch (Exception)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Nu s-a putut adauga un elev nou!");
            }

            return msg;
        }

        // PUT: api/Elev/5
        public HttpResponseMessage Put(int id, HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                t_elev elev = catalog.Elevi.Where(elevcautat => elevcautat.Id == id).FirstOrDefault();
                ElevDTO elevnou = JsonConvert.DeserializeObject<ElevDTO>(value);

                elev.Id = elevnou.Id;
                elev.Data = elevnou.Data;
                elev.Email = elevnou.Email;
                elev.Numar_Matricol = elevnou.Numar_Matricol;
                elev.Nume = elevnou.Nume;
                elev.Parola = elevnou.Parola;
                elev.Prenume = elevnou.Prenume;
                elev.Telefon = elevnou.Telefon;

                t_clasa clasa = catalog.Clase.Where(clasacautata => clasacautata.Id == elevnou.ClasaID).FirstOrDefault();
                elev.Clasa = clasa;
               
                //Lista de Note
                //Lista de Observatii
                //Lista de Absente
                

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
            elev.Data = Elev_schimbat.Data;
            elev.Telefon = Elev_schimbat.Telefon;
            elev.Email = Elev_schimbat.Email;
            elev.Numar_Matricol = Elev_schimbat.Numar_Matricol;
            elev.ClasaID = Elev_schimbat.ClasaID;
            //elev.Clasa = Elev_schimbat.Clasa;
            //elev.Note = Elev_schimbat.Note;
            //elev.Absente = Elev_schimbat.Absente;
            //elev.Observatii = Elev_schimbat.Observatii;

            catalog.SaveChanges();
            
        }

        // DELETE: api/Elev/5
        public HttpResponseMessage Delete(int id)
        {
            var msg = new HttpResponseMessage();

            try
            {
                t_elev elev = catalog.Elevi.Where(elevcautat => elevcautat.Id == id).FirstOrDefault();
                catalog.Elevi.Remove(elev);

                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Stergerea a fost executata cu succes!");
            }
            catch (Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Elevul dorit nu a putut fi sters!");
            }

            return msg;
        }
    }
}
