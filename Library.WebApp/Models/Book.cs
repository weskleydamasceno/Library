using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public class Book
    {
        public Book()
        {
            LocationBooks = new List<LocationBook>();
            BookAuthors = new List<BookAuthor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public int Edition { get; set; }
        public int Volume { get; set; }
        public string PublishingCompany{ get; set; }
        public int NumberCopies { get; set; }

        public virtual ICollection<LocationBook> LocationBooks { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
