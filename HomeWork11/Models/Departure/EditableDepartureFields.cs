﻿using System;

namespace HomeWork11.Models.Departure
{
    public class EditableDepartureFields
    {
        public int FlightId { get; set; }
        public DateTime DepartureDate { get; set; }
        public int CrewId { get; set; }
        public int PlaneId { get; set; }
    }
}