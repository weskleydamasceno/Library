using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public class LocationBook
    {
        public int Id { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal fine  { get; set; }
        public int LocationId { get; set; }
        public int BookId { get; set; }
        public virtual Location Location { get; set; }
        public virtual Book Book { get; set; }
    }
}
