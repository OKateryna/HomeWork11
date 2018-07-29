using System.Collections.Generic;

namespace HomeWork11.Models.Crew
{
    public class Crew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Pilot.Pilot Pilot { get; set; }
        public IEnumerable<Stewardess.Stewardess> Stewardesses { get; set; }
    }
}