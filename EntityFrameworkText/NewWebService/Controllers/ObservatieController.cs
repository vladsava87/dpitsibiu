using AutoMapper;
using DatabaseLayer;
using DatabaseLayer.DataModels;
using DatabaseLayer.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System;

namespace NewWebService.Controllers
{

    public class ObservatieController : ApiController
    {
        private CatalogContex catalog = new CatalogContex();
        
        // GET api/values
        public IEnumerable<ObservatieDTO> Get()
        {
            var obs = catalog.Observatii.ToList();

            var tObs = Mapper.Map<List<ObservatieDTO>>(obs);

            return tObs;
        }

        // GET api/values/5
        public ObservatieDTO Get(int id)
        {
            var obs = catalog.Observatii.Where(observatie => observatie.Id == id).FirstOrDefault();

            var tobs = Mapper.Map<ObservatieDTO>(obs);

            return tobs;
        }

        // POST api/values
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                ObservatieDTO obs = JsonConvert.DeserializeObject<ObservatieDTO>(value);
                t_observatie obsnou = Mapper.Map<ObservatieDTO, t_observatie>(obs);

                catalog.Observatii.Add(obsnou);
                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("O observatie noua a fost adaugata!");
            }
            catch(Exception)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Nu s-a putut adauga o observatie noua!");
            }

            return msg;
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, HttpRequestMessage request)
        {
            var msg = new HttpResponseMessage();

            try
            {
                var value = request.Content.ReadAsStringAsync().Result;

                t_observatie obs = catalog.Observatii.Where(obscautat => obscautat.Id == id).FirstOrDefault();
                ObservatieDTO obsnou = JsonConvert.DeserializeObject<ObservatieDTO>(value);

                obs.Id = obsnou.Id;
                obs.Data = obsnou.Data;
                obs.Text = obsnou.Text;
                

                t_elev elev = catalog.Elevi.Where(elevcautat => elevcautat.Id == obsnou.ElevID).FirstOrDefault();
                obs.Elev = elev;
                t_profesor profesor = catalog.Profesorii.Where(profesorcautat => profesorcautat.Id == obsnou.ProfesorID).FirstOrDefault();
                obs.Profesor = profesor;
                

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

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            var msg = new HttpResponseMessage();

            try
            {
                t_observatie obs = catalog.Observatii.Where(obscautat => obscautat.Id == id).FirstOrDefault();
                catalog.Observatii.Remove(obs);

                catalog.SaveChanges();

                msg.StatusCode = System.Net.HttpStatusCode.OK;
                msg.Content = new StringContent("Stergerea a fost executata cu succes!");
            }
            catch (Exception ex)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("Observatia dorita nu a putut fi stearsa!");
            }

            return msg;
        }
    }
}

