using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.WebApp.Models;

namespace Library.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly LibraryContext _context;

        public AuthorController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetById(int id)
        {
            var item = _context.Authors.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Author item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Authors.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetAuthor", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Author item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var author = _context.Authors.FirstOrDefault(t => t.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            author.Name = item.Name;

            _context.Authors.Update(author);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _context.Authors.FirstOrDefault(t => t.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
