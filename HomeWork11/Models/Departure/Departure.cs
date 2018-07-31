using System;

namespace HomeWork11.Models.Departure
{
    public class Departure : Entity
    {
        public Flight.Flight Flight { get; set; }
        public DateTime DepartureDate { get; set; }
        public Crew.Crew Crew { get; set; }
        public Plane.Plane Plane { get; set; }
    }
}