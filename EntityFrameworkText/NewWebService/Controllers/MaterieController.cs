using AutoMapper;
using DatabaseLayer;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewWebService.Controllers
{
    public class MaterieController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Materie
        public IEnumerable<MaterieDTO> Get()
        {
            var Materie = catalog.Materii.ToList();

            var tMaterie = Mapper.Map<List<MaterieDTO>>(Materie);

            return tMaterie;
        }

        // GET: api/Materie/5
        public MaterieDTO Get(int id)
        {
            var Materie = catalog.Materii.Where(m => m.Id == id).FirstOrDefault();

            var tMaterie = Mapper.Map<MaterieDTO>(Materie);

            return tMaterie;

        }

        // POST: api/Materie
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                MaterieDTO materie = JsonConvert.DeserializeObject<MaterieDTO>(value);
                t_materie materienoua = Mapper.Map<MaterieDTO, t_materie>(materie);

                catalog.Materii.Add(materienoua);
                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("O materie noua a fost adaugata!");
            }
            catch (Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Nu s-a putut adauga o materie noua!");
            }

            return msg;
        }

        // PUT: api/Materie/5
        public HttpResponseMessage Put(int id, HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                t_materie materie = catalog.Materii.Where(materiecautata => materiecautata.Id == id).FirstOrDefault();
                MaterieDTO materienoua = JsonConvert.DeserializeObject<MaterieDTO>(value);

                materie.Id = materienoua.Id;
                materie.Nume = materienoua.Nume;
                materie.Optional = materienoua.Optional;
                
                //Lista de Note
                //Lista de Profesori

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

        // DELETE: api/Materie/5
        public HttpResponseMessage Delete(int id)
        {
            var msg = new HttpResponseMessage();

            try
            {
                t_materie materie = catalog.Materii.Where(materiecautata => materiecautata.Id == id).FirstOrDefault();
                catalog.Materii.Remove(materie);

                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Stergerea a fost executata cu succes!");
            }
            catch (Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Materia dorita nu a putut fi stearsa!");
            }

            return msg;
        }
    }
}
