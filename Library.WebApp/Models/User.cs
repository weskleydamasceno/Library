﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Models
{
    public class User
    {
        public User()
        {
            Locations = new List<Location>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Street { get; set; }
        public string district { get; set; }
        public string City { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
