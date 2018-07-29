using System;
using System.Collections.Generic;

namespace HomeWork11.Models.Flight
{
    public class Flight
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string PlaceDeparture { get; set; }
        public DateTime TimeDeparture { get; set; }
        public string Destination { get; set; }
        public DateTime TimeDestination { get; set; }
        public virtual ICollection<Ticket.Ticket> Tickets { get; set; }
    }
}