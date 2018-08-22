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
        public void Post(HttpRequestMessage request)
        {
            var value = request.Content.ReadAsStringAsync().Result;

            MaterieDTO Materie = JsonConvert.DeserializeObject<MaterieDTO>(value);
            t_materie Materienoua = Mapper.Map<MaterieDTO, t_materie>(Materie);



            //catalog.Materii.Add(new MaterieDTO()
            //    {
            //        Id = Materie.Id,
            //        Nume = Materie.Nume,
            //        Optional = Materie.Optional,
            //        Absente = Materie.Absente,
            //        Note = Materie.Note



            //});
            catalog.Materii.Add(Materienoua);
            catalog.SaveChanges();



        }

        // PUT: api/Materie/5
        public void Put(int id, HttpRequestMessage request)
        {
            var value = request.Content.ReadAsStringAsync().Result;

            t_materie Materie = catalog.Materii.Where(m => m.Id == id).FirstOrDefault();
            MaterieDTO Materienoua = JsonConvert.DeserializeObject<MaterieDTO>(value);

            Materie.Id = Materienoua.Id;
            Materie.Nume = Materienoua.Nume;
            Materie.Optional = Materienoua.Optional;
            //Materie.Absente = Materienoua.Absente;
            //Materie.Note = Materienoua.Note;

        }

        // DELETE: api/Materie/5
        public void Delete(int id)
        {
            t_materie Materie = catalog.Materii.Where(m => m.Id == id).FirstOrDefault();
            catalog.Materii.Remove(Materie);
            catalog.SaveChanges();
        }
    }
}
