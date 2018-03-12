﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public class Location
    {
        public Location()
        {
            this.Date = DateTime.Now;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
