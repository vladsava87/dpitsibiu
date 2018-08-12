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
                msg.Content = new StringContent("POST Request performed successfully");
            }
            catch (Exception)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("POST Request could not be performed");
            }

            return msg;
        }

        // PUT: api/Profil/5
        public void Put(int id, HttpRequestMessage request)
        {
            var value = request.Content.ReadAsStringAsync().Result;

            ProfilDTO profilnou = JsonConvert.DeserializeObject<ProfilDTO>(value);
            t_profil Profil = catalog.Profiluri.Where(p => p.Id == id).FirstOrDefault();

            Profil.Id = profilnou.Id;
            Profil.Nume = profilnou.Nume;
        }

        // DELETE: api/Profil/5
        public void Delete(int id)
        {
            t_profil Profil = catalog.Profiluri.Where(p => p.Id == id).FirstOrDefault();
            catalog.Profiluri.Remove(Profil);
            catalog.SaveChanges();
        }
    }
}
