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
                msg.Content = new StringContent("POST Request performed successfully");
            }
            catch(Exception e)
            {
                msg.StatusCode = System.Net.HttpStatusCode.BadRequest;
                msg.Content = new StringContent("POST Request could not be performed");
            }

            return msg;
        }

        // PUT api/values/5
        public void Put(int id, HttpRequestMessage request)
        {
            var value = request.Content.ReadAsStringAsync().Result;

            ObservatieDTO obsdes = JsonConvert.DeserializeObject<ObservatieDTO>(value);
            t_observatie obs = catalog.Observatii.Where(observatie => observatie.Id == id).FirstOrDefault();
            
            obs.Id = obsdes.Id;
            obs.Data = obsdes.Data;
            obs.Text = obsdes.Text;

            t_profesor prof = catalog.Profesorii.Where(profesor => profesor.Id == obsdes.ProfesorID).FirstOrDefault();
            obs.Profesor = prof;
            t_elev elev = catalog.Elevi.Where(elevul => elevul.Id == obsdes.ElevID).FirstOrDefault();
            obs.Elev = elev;

            catalog.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            t_observatie obs = catalog.Observatii.Where(observatie => observatie.Id == id).FirstOrDefault();
            catalog.Observatii.Remove(obs);

            catalog.SaveChanges();
        }
    }
}
