﻿using System;
using System.Collections.Generic;

namespace Cinema.Data.Models
{
    public class Projection
    {
        public Projection()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public int HallId { get; set; }

        public virtual Hall Hall { get; set; }
        
        public DateTime DateTime { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}