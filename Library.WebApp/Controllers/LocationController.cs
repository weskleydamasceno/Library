using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.WebApp.Models;

namespace Library.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly LibraryContext _context;

        public LocationController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Location> GetAll()
        {
            return _context.Locations.ToList();
        }

        [HttpGet("{id}", Name = "GetLocation")]
        public IActionResult GetById(int id)
        {
            var item = _context.Locations.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Location item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Locations.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetLocation", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Location item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var location = _context.Locations.FirstOrDefault(t => t.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            location.Number = item.Number;
            location.Date = item.Date;

            _context.Locations.Update(location);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var location = _context.Locations.FirstOrDefault(t => t.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
