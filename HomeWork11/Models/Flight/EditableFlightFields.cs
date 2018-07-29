﻿using System;

namespace HomeWork11.Models.Flight
{
    public class EditableFlightFields
    {
        public string Number { get; set; }
        public string PlaceDeparture { get; set; }
        public DateTime TimeDeparture { get; set; }
        public string Destination { get; set; }
        public DateTime TimeDestination { get; set; }
        public int[] TicketIds { get; set; }
    }
}