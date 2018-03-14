﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Author Author{ get; set; }
    }
}
