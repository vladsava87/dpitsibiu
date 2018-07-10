using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        private readonly WebApiContext _context;

        public WebApiController(WebApiContext context)
        {
            _context = context;

            if(_context.WebApiItems.Count() == 0)
            {
                _context.WebApiItems.Add(new WebApiItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<WebApiItem>> GetAll()
        {
            return _context.WebApiItems.ToList();
        }

        [HttpGet("{id}", Name = "GetWebApi")]
        public ActionResult<WebApiItem> GetById(long id)
        {
            var item = _context.WebApiItems.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(WebApiItem item)
        {
            _context.WebApiItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetWebApi", new { id = item.Id }, item);
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<WebApiItem> GetById(int id)
        {
            var item = _context.WebApiItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, WebApiItem item)
        {
            var webapi = _context.WebApiItems.Find(id);
            if (webapi == null)
            {
                return NotFound();
            }

            webapi.IsComplete = item.IsComplete;
            webapi.Name = item.Name;

            _context.WebApiItems.Update(webapi);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var webapi = _context.WebApiItems.Find(id);
            if (webapi == null)
            {
                return NotFound();
            }

            _context.WebApiItems.Remove(webapi);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
