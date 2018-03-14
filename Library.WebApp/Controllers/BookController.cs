using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.WebApp.Models;

namespace Library.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetById(int id)
        {
            var item = _context.Books.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Books.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetBook", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var book = _context.Books.FirstOrDefault(t => t.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            book.Name = item.Name;
            book.Isbn = item.Isbn;
            book.Edition = item.Edition;
            book.Volume = item.Volume;
            book.PublishingCompany = item.PublishingCompany;
            book.NumberCopies = item.NumberCopies;

            _context.Books.Update(book);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(t => t.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
