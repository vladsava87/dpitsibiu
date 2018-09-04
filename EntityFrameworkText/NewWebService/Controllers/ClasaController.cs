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
    public class ClasaController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Clasa
        public IEnumerable<ClasaDTO> Get()
        {
            var clase = catalog.Clase.ToList();

            var tclase = Mapper.Map<List<ClasaDTO>>(clase);

            return tclase;
        }

        // GET: api/Clasa/5
        public ClasaDTO Get(int id)
        {
            var clasa = catalog.Clase.Where(c => c.Id == id).FirstOrDefault();

            var tclasa = Mapper.Map<ClasaDTO>(clasa);

            return tclasa;
        }

        // POST: api/Clasa
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();
            
            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                ClasaDTO clasa = JsonConvert.DeserializeObject<ClasaDTO>(value);
                t_clasa clasanoua = Mapper.Map<ClasaDTO, t_clasa>(clasa);

                catalog.Clase.Add(clasanoua);
                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("O clasa noua a fost adaugata!");
            }
            catch(Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Nu s-a putut adauga o clasa noua!");
            }

            return msg;
        }

        // PUT: api/Clasa/5
        public HttpResponseMessage Put(int id, HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            { 
                var value = request.Content.ReadAsStringAsync().Result;

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

        // DELETE: api/Clasa/5
        public HttpResponseMessage Delete(int id)
        {
            var msg = new HttpResponseMessage();

            try
            { 
                t_clasa clasa = catalog.Clase.Where(clasacautata => clasacautata.Id == id).FirstOrDefault();
                catalog.Clase.Remove(clasa);

                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Stergerea a fost executata cu succes!");
            }
            catch(Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Clasa dorita nu a putut fi stearsa!");
            }

            return msg;
        }
    }
}
