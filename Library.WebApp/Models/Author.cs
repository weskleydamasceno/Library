using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public class Author
    {
        public Author()
        {
            BookAuthors = new List<BookAuthor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
