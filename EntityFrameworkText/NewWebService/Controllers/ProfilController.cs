
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

namespace NewWebService.Controllers
{
    public class ProfilController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Profil
        public IEnumerable<ProfilDTO> Get()
        {
            var profile = catalog.Profiluri.ToList();

            var tProfile = Mapper.Map<List<ProfilDTO>>(profile);

            return tProfile;
        }

        // GET: api/Profil/5
        public ProfilDTO Get(int id)
        {
            var profil = catalog.Profiluri.Where(p => p.Id == id).FirstOrDefault();

            var tprofil = Mapper.Map<ProfilDTO>(profil);

            return tprofil;
        }

        // POST: api/Profil
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                ProfilDTO profil = JsonConvert.DeserializeObject<ProfilDTO>(value);
                t_profil profilnou = Mapper.Map<ProfilDTO, t_profil>(profil);

                catalog.Profiluri.Add(profilnou);
                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Un profil nou a fost adaugat!");
            }
            catch (Exception)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Nu s-a putut adauga un profil nou!");
            }

            return msg;
        }

        // PUT: api/Profil/5
        public HttpResponseMessage Put(int id, HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                t_profil profil = catalog.Profiluri.Where(profilcautat => profilcautat.Id == id).FirstOrDefault();
                ProfilDTO profilnou = JsonConvert.DeserializeObject<ProfilDTO>(value);

                profil.Id = profilnou.Id;
                profil.Nume = profilnou.Nume;

              
                //Lista de Clase

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

        // DELETE: api/Profil/5
        public HttpResponseMessage Delete(int id)
        {
            var msg = new HttpResponseMessage();

            try
            {
                t_profil profil = catalog.Profiluri.Where(profilcautat => profilcautat.Id == id).FirstOrDefault();
                catalog.Profiluri.Remove(profil);

                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Stergerea a fost executata cu succes!");
            }
            catch (Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Profilul dorit nu a putut fi sters!");
            }

            return msg;
        }
    }
}