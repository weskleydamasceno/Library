using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.WebApp.Models;

namespace Library.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class BookAuthorController : Controller
    {
        private readonly LibraryContext _context;

        public BookAuthorController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<BookAuthor> GetAll()
        {
            return _context.BooksAuthors.ToList();
        }

        [HttpGet("{id}", Name = "GetBookAuthor")]
        public IActionResult GetById(int id)
        {
            var item = _context.BooksAuthors.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookAuthor item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.BooksAuthors.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetBookAuthor", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BookAuthor item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var bookAuthor = _context.BooksAuthors.FirstOrDefault(t => t.Id == id);
            if (bookAuthor == null)
            {
                return NotFound();
            }
            
            _context.BooksAuthors.Update(bookAuthor);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookAuthor = _context.BooksAuthors.FirstOrDefault(t => t.Id == id);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            _context.BooksAuthors.Remove(bookAuthor);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
