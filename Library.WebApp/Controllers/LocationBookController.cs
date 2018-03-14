using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.WebApp.Models;

namespace Library.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class LocationBookController : Controller
    {
        private readonly LibraryContext _context;

        public LocationBookController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<LocationBook> GetAll()
        {
            return _context.LocationsBooks.ToList();
        }

        [HttpGet("{id}", Name = "GetLocationBook")]
        public IActionResult GetById(int id)
        {
            var item = _context.LocationsBooks.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] LocationBook item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.LocationsBooks.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetLocationBook", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LocationBook item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var locationBook = _context.LocationsBooks.FirstOrDefault(t => t.Id == id);
            if (locationBook == null)
            {
                return NotFound();
            }

            locationBook.ReturnDate = item.ReturnDate;
            locationBook.fine = item.fine;

            _context.LocationsBooks.Update(locationBook);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var locationBook = _context.LocationsBooks.FirstOrDefault(t => t.Id == id);
            if (locationBook == null)
            {
                return NotFound();
            }

            _context.LocationsBooks.Remove(locationBook);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
