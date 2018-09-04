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
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                AbsentaDTO absenta = JsonConvert.DeserializeObject<AbsentaDTO>(value);
                t_absenta absentanoua = Mapper.Map<AbsentaDTO, t_absenta>(absenta);

                catalog.Absente.Add(absentanoua);
                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("O absenta noua a fost adaugata!");
            }
            catch (Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Nu s-a putut adauga o absenta noua!");
            }

            return msg;

        }

        // PUT: api/Absenta/5
        public HttpResponseMessage Put(int id, HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                t_absenta absenta = catalog.Absente.Where(absentacautata => absentacautata.Id == id).FirstOrDefault();
                AbsentaDTO absentanoua = JsonConvert.DeserializeObject<AbsentaDTO>(value);

                absenta.Id = absentanoua.Id;
                absenta.Data = absentanoua.Data;
                //absenta.ElevID = absentanoua.ElevID;
                //absenta.Elev = absentanoua.Elev;
                //absenta.MaterieID = absentanoua.MaterieID;
                //absenta.Materie = absentanoua.Materie;



                t_elev elev = catalog.Elevi.Where(elevcautat => elevcautat.Id == absentanoua.ElevID).FirstOrDefault();
                absenta.Elev = elev;
                t_materie materie = catalog.Materii.Where(materiecautata => materiecautata.Id == absentanoua.MaterieID).FirstOrDefault();
                absenta.Materie = materie;
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


        // DELETE: api/Absenta/5
        public HttpResponseMessage Delete(int id)
        {
            var msg = new HttpResponseMessage();

            try
            {
                t_absenta absenta = catalog.Absente.Where(absentacautata => absentacautata.Id == id).FirstOrDefault();
                catalog.Absente.Remove(absenta);

                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Stergerea a fost executata cu succes!");
            }
            catch (Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Absenta dorita nu a putut fi stearsa!");
            }

            return msg;
        }
    }
}
}
