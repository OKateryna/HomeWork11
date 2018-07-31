using System;

namespace HomeWork11.Models.Pilot
{
    public class Pilot : Entity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Experience { get; set; }
    }
}