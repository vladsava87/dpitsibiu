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
        public object Get(int id)
        {
            var Nota = catalog.Note.Where(n => n.Elev.Id == id).ToList();

            var tNota = Mapper.Map<List<NotaDTO>>(Nota);

            return tNota;
        }

        // POST: api/Nota
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                NotaDTO nota = JsonConvert.DeserializeObject<NotaDTO>(value);
                t_nota notanoua = Mapper.Map<NotaDTO, t_nota>(nota);

                catalog.Note.Add(notanoua);
                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("O nota noua a fost adaugata!");
            }
            catch (Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Nu s-a putut adauga o nota noua!");
            }

            return msg;
        }

        // PUT: api/Nota/5
        public HttpResponseMessage Put(int id, HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                t_nota nota = catalog.Note.Where(notacautata => notacautata.Id == id).FirstOrDefault();
                NotaDTO notanoua = JsonConvert.DeserializeObject<NotaDTO>(value);

                nota.Id = notanoua.Id;
                nota.Data = notanoua.Data;
                nota.Nota = notanoua.Nota;
                nota.Semestrul = notanoua.Semestrul;
                nota.Teza = notanoua.Teza;
                
                t_elev elev = catalog.Elevi.Where(elevcautat => elevcautat.Id == notanoua.ElevID).FirstOrDefault();
                nota.Elev = elev;
                t_materie materie = catalog.Materii.Where(materiecautata => materiecautata.Id == notanoua.MaterieID).FirstOrDefault();
                nota.Materie = materie;
               
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

        // DELETE: api/Nota/5
        public HttpResponseMessage Delete(int id)
        {
            var msg = new HttpResponseMessage();

            try
            {
                t_nota nota = catalog.Note.Where(notacautata => notacautata.Id == id).FirstOrDefault();
                catalog.Note.Remove(nota);

                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Stergerea a fost executata cu succes!");
            }
            catch (Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Nota dorita nu a putut fi stearsa!");
            }

            return msg;
        }
    }
}

