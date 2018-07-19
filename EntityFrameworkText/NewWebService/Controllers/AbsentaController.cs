using AutoMapper;
using Newtonsoft.Json;
using DatabaseLayer;
using DatabaseLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatabaseLayer.DataModels;

namespace NewWebService.Controllers
{
    public class AbsentaController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();

        // GET: api/Absenta
        public IEnumerable<AbsentaDTO> Get()
        {
            var Absente = catalog.Absente.ToList();

            var tAbsente = Mapper.Map<List<AbsentaDTO>>(Absente);

            return tAbsente;
        }

        // GET: api/Absenta/5
        public AbsentaDTO Get(int id)
        {
            var Absenta = catalog.Absente.Where(a => a.Id == id).FirstOrDefault();

            var tAbsenta = Mapper.Map<AbsentaDTO>(Absenta);

            return tAbsenta;

        }


        // POST: api/Absenta
        public void Post([FromBody] string value)
        {
            AbsentaDTO Absenta = JsonConvert.DeserializeObject<AbsentaDTO>(value);
            t_absenta Absentanoua = Mapper.Map<AbsentaDTO, t_absenta>(Absenta);


            //catalog.Absente.Add(new AbsentaDTO()
            //{

            //    Id = Absenta.Id,
            //    Motivata = Absenta.Motivata,
            //    Data = Absenta.Data,
            //    Semestrul = Absenta.Semestrul,
            //    MaterieID = Absenta.MaterieID,
            //    Materie = Absenta.Materie,
            //    ProfesorID = Absenta.ProfesorID,
            //    Profesor = Absenta.Profesor,
            //    ElevID = Absenta.ElevID,
            //    Elev = Absenta.Elev

            //});
            catalog.Absente.Add(Absentanoua);
            catalog.SaveChanges();

        }

        // PUT: api/Absenta/5
        public void Put(int id, [FromBody]string value)
        {
            t_absenta Absenta = catalog.Absente.Where(a => a.Id == id).FirstOrDefault();
            AbsentaDTO Absentanoua = JsonConvert.DeserializeObject<AbsentaDTO>(value);
            //if (!ModelState.IsValid)
            //    return BadRequest("Not a valid model");

            Absenta.Id = Absentanoua.Id;
            Absenta.Motivata = Absentanoua.Motivata;
            Absenta.Data = Absentanoua.Data;
            Absenta.Semestrul = Absentanoua.Semestrul;
            //Absenta.MaterieID = Absentanoua.MaterieID;
            t_materie Materie = catalog.Materii.Where(m => m.Id == Absentanoua.Id).FirstOrDefault();
            Absenta.Materie = Materie;
            //Absenta.ProfesorId = Absentanoua.ProfesorID;
            t_profesor Profesor = catalog.Profesorii.Where(p => p.Id == Absentanoua.Id).FirstOrDefault();
            Absenta.Profesor = Profesor;

            //var existingAbsenta = catalog.Absente.Where(a => a == Absenta.Id).FirstorDefault<AbsentaDTO>();

            //if (existingAbsenta != null)
            //{
            //    existingAbsenta.Id = Absenta.Id;
            //    existingAbsenta.Motivata = Absenta.Motivata;
            //    existingAbsenta.Data = Absenta.Data;
            //    existingAbsenta.Semestrul = Absenta.Semestrul;
            //    existingAbsenta.MaterieId = Absenta.MaterieID;
            //    existingAbsenta.Materie = Absenta.Materie;
            //    existingAbsenta.ProfesorId = Absenta.ProfesorID;
            //    existingAbsenta.Profesor = Absenta.Profesor;
            //    existingAbsenta.ElevId = Absenta.ElevID;
            //    existingAbsenta.Elev = Absenta.Elev;

            //catalog.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}


        }


        // DELETE: api/Absenta/5
        public void Delete(int id)
        {
            t_absenta Absenta = catalog.Absente.Where(a => a.Id == id).FirstOrDefault();
            catalog.Absente.Remove(Absenta);
            catalog.SaveChanges();
        }
    }
}
