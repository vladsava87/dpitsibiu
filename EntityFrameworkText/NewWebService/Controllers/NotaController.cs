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
    public class NotaController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Nota
        public IEnumerable<NotaDTO> Get()
        {
            var Note = catalog.Note.ToList();

            var tNote = Mapper.Map<List<NotaDTO>>(Note);

            return tNote;
        }

        // GET: api/Nota/5
        public NotaDTO Get(int id)
        {
            var Nota = catalog.Note.Where(n => n.Id == id).FirstOrDefault();

            var tNota = Mapper.Map<NotaDTO>(Nota);

            return tNota;
        }

        // POST: api/Nota
        public void Post(HttpRequestMessage request)
        {
            var value = request.Content.ReadAsStringAsync().Result;

            NotaDTO Nota = JsonConvert.DeserializeObject<NotaDTO>(value);
            t_nota Notanoua = Mapper.Map<NotaDTO, t_nota>(Nota);

            //    catalog.Note.Add(new NotaDTO()
            //    {

            //        Id = Nota.Id,
            //        Nota = Nota.Nota,
            //        Teza = Nota.Teza,
            //        Semestrul = Nota.Semestrul,
            //        Data = Nota.Data,
            //        ElevID = Nota.ElevID,
            //        Elev = Nota.Elev,
            //        MaterieID = Nota.MaterieID,
            //        Materie = Nota.Materie

            //});

            catalog.Note.Add(Notanoua);
            catalog.SaveChanges();


        }

        // PUT: api/Nota/5
        public void Put(int id, HttpRequestMessage request)
        {
            var value = request.Content.ReadAsStringAsync().Result;

            t_nota Nota = catalog.Note.Where(n => n.Id == id).FirstOrDefault();
            NotaDTO Notanoua = JsonConvert.DeserializeObject<NotaDTO>(value);


            Nota.Id = Notanoua.Id;
            Nota.Nota = Notanoua.Nota;
            Nota.Teza = Notanoua.Teza;
            Nota.Semestrul = Notanoua.Semestrul;
            Nota.Data = Notanoua.Data;
            Nota.ElevID = Notanoua.ElevID;
            t_elev Elev = catalog.Elevi.Where(e => e.Id == Nota.Id).FirstOrDefault();
            Nota.Elev = Elev;
            // Nota.Elev = Notades.Elev;
            Nota.MaterieID = Notanoua.MaterieID;
            t_materie materie = catalog.Materii.Where(m => m.Id == Nota.MaterieID).FirstOrDefault();
            Nota.Materie = materie;
            // Nota.Materie = Notades.Materie;



            //var tNota = Mapper.Map<NotaDTO, t_nota>(Nota);
            //t_nota newNota = Mapper.Map<NotaDTO, t_nota>(tNota);




            //var existingNota = catalog.Note.Where(n => n = Nota.Id).FirstorDefault<NotaDTO>();

            //if (existingNota != null)
            //{
            //    existingNota.Id = Nota.Id;
            //    existingNota.Nota = Nota.Nota;
            //    existingNota.Teza = Nota.Teza;
            //    existingNota.Semestrul = Nota.Semestrul;
            //    existingNota.Data = Nota.Data;
            //    existingNota.ElevId = Nota.ElevID;
            //    existingNota.Elev = Nota.Elev;
            //    existingNota.MaterieId = Nota.MaterieID;
            //    existingNota.Materie = Nota.Materie;

            //    catalog.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}

            catalog.SaveChanges();


        }

        // DELETE: api/Nota/5
        public void Delete(int id)
        {
            t_nota Nota = catalog.Note.Where(n => n.Id == id).FirstOrDefault();
            catalog.Note.Remove(Nota);
            catalog.SaveChanges();

        }
    }
}
